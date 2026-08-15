using FastCart.Inventory;
using FastCart.Models;

namespace FastCart.Services;

/// <summary>
/// Administra una cola dinámica FIFO de pedidos.
/// </summary>
public class ColaDespacho
{
    private NodoCola? _frente;
    private NodoCola? _fin;
    private int _totalEncolados;

    /// <summary>
    /// Indica si la cola está vacía.
    /// </summary>
    public bool EstaVacia => _frente == null;

    /// <summary>
    /// Obtiene la cantidad de pedidos actualmente en la cola.
    /// </summary>
    public int TotalEncolados => _totalEncolados;

    /// <summary>
    /// Inserta un pedido al final de la cola.
    /// Complejidad temporal: O(1).
    /// </summary>
    /// <param name="nuevoPedido">Pedido que se desea encolar.</param>
    public void EncolarPedido(Pedido nuevoPedido)
    {
        if (nuevoPedido == null)
        {
            throw new ArgumentNullException(
                nameof(nuevoPedido),
                "El pedido no puede ser nulo."
            );
        }

        NodoCola nuevoNodo = new NodoCola(nuevoPedido);

        if (EstaVacia)
        {
            _frente = nuevoNodo;
            _fin = nuevoNodo;
        }
        else
        {
            _fin!.Siguiente = nuevoNodo;
            _fin = nuevoNodo;
        }

        _totalEncolados++;
    }

    /// <summary>
    /// Extrae el pedido que se encuentra al frente de la cola,
    /// actualiza el stock y registra la operación en la bitácora.
    /// </summary>
    /// <param name="catalogo">Catálogo de productos.</param>
    /// <param name="auditoria">Servicio de auditoría.</param>
    /// <returns>
    /// El pedido despachado o null cuando no puede realizarse.
    /// </returns>
    public Pedido? DespacharPedido(
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

        Pedido pedidoDespachado = _frente!.Data;

        _frente = _frente.Siguiente;

        if (_frente == null)
        {
            _fin = null;
        }

        _totalEncolados--;

        try
        {
            Fase2.Producto producto = catalogo.BuscarPorSKU(
                pedidoDespachado.SKU
            );

            if (producto.Stock < pedidoDespachado.Cantidad)
            {
                LogMovimiento movimiento = new LogMovimiento
                {
                    TipoOperacion = "STOCK_INSUFICIENTE",
                    ProductoId = pedidoDespachado.SKU,
                    Referencia =
                        $"Stock insuficiente para pedido #{pedidoDespachado.IdPedido}.",
                    FechaHora = DateTime.Now
                };

                auditoria.RegistrarEvento(movimiento);

                return null;
            }

            producto.Stock -= pedidoDespachado.Cantidad;

            bool actualizado = catalogo.ActualizarProducto(
                pedidoDespachado.SKU,
                producto
            );

            if (!actualizado)
            {
                LogMovimiento movimiento = new LogMovimiento
                {
                    TipoOperacion = "DESPACHO_FALLIDO",
                    ProductoId = pedidoDespachado.SKU,
                    Referencia =
                        $"No fue posible actualizar el SKU {pedidoDespachado.SKU}.",
                    FechaHora = DateTime.Now
                };

                auditoria.RegistrarEvento(movimiento);

                return null;
            }

            LogMovimiento despacho = new LogMovimiento
            {
                TipoOperacion = "DESPACHO_EXITOSO",
                ProductoId = pedidoDespachado.SKU,
                Referencia =
                    $"Pedido #{pedidoDespachado.IdPedido} despachado. " +
                    $"Cantidad: {pedidoDespachado.Cantidad}. " +
                    $"Stock restante: {producto.Stock}.",
                FechaHora = DateTime.Now
            };

            auditoria.RegistrarEvento(despacho);

            return pedidoDespachado;
        }
        catch (KeyNotFoundException)
        {
            LogMovimiento movimiento = new LogMovimiento
            {
                TipoOperacion = "DESPACHO_FALLIDO",
                ProductoId = pedidoDespachado.SKU,
                Referencia =
                    $"SKU {pedidoDespachado.SKU} no encontrado en catálogo.",
                FechaHora = DateTime.Now
            };

            auditoria.RegistrarEvento(movimiento);

            return null;
        }
    }
}