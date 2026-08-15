using FastCart.Inventory;
using FastCart.Models;

namespace FastCart.Services;

/// <summary>
/// Administra una pila dinámica LIFO de devoluciones.
/// </summary>
public class PilaDevoluciones
{
    private NodoPila? _top;
    private int _totalDevoluciones;

    /// <summary>
    /// Indica si la pila está vacía.
    /// </summary>
    public bool EstaVacia => _top == null;

    /// <summary>
    /// Obtiene la cantidad de devoluciones almacenadas.
    /// </summary>
    public int TotalDevoluciones => _totalDevoluciones;

    /// <summary>
    /// Inserta una devolución en la parte superior de la pila.
    /// Complejidad temporal: O(1).
    /// </summary>
    /// <param name="devolucion">Devolución que se desea registrar.</param>
    public void PushDevolucion(Devolucion devolucion)
    {
        if (devolucion == null)
        {
            throw new ArgumentNullException(
                nameof(devolucion),
                "La devolución no puede ser nula."
            );
        }

        NodoPila nuevoNodo = new NodoPila(devolucion);

        nuevoNodo.Siguiente = _top;
        _top = nuevoNodo;

        _totalDevoluciones++;
    }

    /// <summary>
    /// Extrae la devolución más reciente de la pila,
    /// reintegra el stock y registra la operación en la bitácora.
    /// </summary>
    /// <param name="catalogo">Catálogo de productos.</param>
    /// <param name="auditoria">Servicio de auditoría.</param>
    /// <returns>
    /// La devolución procesada o null cuando no puede procesarse.
    /// </returns>
    public Devolucion? PopDevolucion(
        InventarioLista catalogo,
        AuditoriaService auditoria)
    {
        if (catalogo == null)
        {
            throw new ArgumentNullException(nameof(catalogo));
        }

        if (auditoria == null)
        {
            throw new ArgumentNullException(nameof(auditoria));
        }

        if (EstaVacia)
        {
            return null;
        }

        Devolucion devolucion = _top!.Data;

        _top = _top.Siguiente;
        _totalDevoluciones--;

        try
        {
            Fase2.Producto producto = catalogo.BuscarPorSKU(
                devolucion.SKU
            );

            producto.Stock += devolucion.Cantidad;

            bool actualizado = catalogo.ActualizarProducto(
                devolucion.SKU,
                producto
            );

            if (!actualizado)
            {
                LogMovimiento movimiento = new LogMovimiento
                {
                    TipoOperacion = "DEVOLUCION_FALLIDA",
                    ProductoId = devolucion.SKU,
                    Referencia =
                        $"No fue posible actualizar el SKU {devolucion.SKU}.",
                    FechaHora = DateTime.Now
                };

                auditoria.RegistrarEvento(movimiento);

                return null;
            }

            LogMovimiento registro = new LogMovimiento
            {
                TipoOperacion = "DEVOLUCION_EXITOSA",
                ProductoId = devolucion.SKU,
                Referencia =
                    $"Devolución #{devolucion.IdDevolucion} procesada. " +
                    $"Cantidad reintegrada: {devolucion.Cantidad}. " +
                    $"Stock actual: {producto.Stock}.",
                FechaHora = DateTime.Now
            };

            auditoria.RegistrarEvento(registro);

            return devolucion;
        }
        catch (KeyNotFoundException)
        {
            LogMovimiento movimiento = new LogMovimiento
            {
                TipoOperacion = "DEVOLUCION_FALLIDA",
                ProductoId = devolucion.SKU,
                Referencia =
                    $"SKU {devolucion.SKU} no encontrado en catálogo.",
                FechaHora = DateTime.Now
            };

            auditoria.RegistrarEvento(movimiento);

            return null;
        }
    }
}