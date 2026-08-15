using Fase2;
using FastCart.Models;
using FastCart.Services;

namespace FastCart.Inventory;

/// <summary>
/// Administra el catálogo mediante una lista simplemente enlazada
/// e integra la bitácora de auditoría.
/// </summary>
public class InventarioLista
{
    private NodoProducto? _cabeza;
    private int _totalProductos;
    private readonly AuditoriaService _auditoria;

    /// <summary>
    /// Obtiene la cantidad total de productos registrados.
    /// </summary>
    public int TotalProductos => _totalProductos;

    /// <summary>
    /// Inicializa el inventario con el servicio de auditoría.
    /// </summary>
    /// <param name="auditoria">Servicio utilizado para registrar movimientos.</param>
    /// <exception cref="ArgumentNullException">
    /// Se produce cuando el servicio de auditoría es nulo.
    /// </exception>
    public InventarioLista(AuditoriaService auditoria)
    {
        _auditoria = auditoria
            ?? throw new ArgumentNullException(nameof(auditoria));
    }

    /// <summary>
    /// Inserta un producto al inicio de la lista.
    /// </summary>
    /// <param name="producto">Producto que se desea insertar.</param>
    public void InsertarInicio(Producto producto)
    {
        NodoProducto nuevo = new NodoProducto(producto);

        nuevo.Siguiente = _cabeza;
        _cabeza = nuevo;

        _totalProductos++;

        RegistrarAuditoria(
            "INSERT",
            producto.SKU,
            $"Producto '{producto.Nombre}' insertado al inicio."
        );
    }

    /// <summary>
    /// Inserta un producto manteniendo la lista ordenada por precio ascendente.
    /// En caso de empate, utiliza el SKU ascendente.
    /// </summary>
    /// <param name="producto">Producto que se desea insertar.</param>
    public void InsertarOrdenado(Producto producto)
    {
        NodoProducto nuevo = new NodoProducto(producto);

        if (_cabeza == null)
        {
            _cabeza = nuevo;
            _totalProductos++;

            RegistrarAuditoria(
                "INSERT",
                producto.SKU,
                $"Producto '{producto.Nombre}' insertado."
            );

            return;
        }

        if (EsMenor(producto, _cabeza.Data))
        {
            nuevo.Siguiente = _cabeza;
            _cabeza = nuevo;
            _totalProductos++;

            RegistrarAuditoria(
                "INSERT",
                producto.SKU,
                $"Producto '{producto.Nombre}' insertado."
            );

            return;
        }

        NodoProducto actual = _cabeza;

        while (actual.Siguiente != null &&
               !EsMenor(producto, actual.Siguiente.Data))
        {
            actual = actual.Siguiente;
        }

        nuevo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevo;

        _totalProductos++;

        RegistrarAuditoria(
            "INSERT",
            producto.SKU,
            $"Producto '{producto.Nombre}' insertado."
        );
    }

    /// <summary>
    /// Busca un producto mediante su SKU.
    /// </summary>
    /// <param name="sku">SKU que se desea localizar.</param>
    /// <returns>El producto encontrado.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Se produce cuando el SKU no existe.
    /// </exception>
    public Producto BuscarPorSKU(int sku)
    {
        NodoProducto? actual = _cabeza;

        while (actual != null)
        {
            if (actual.Data.SKU == sku)
            {
                return actual.Data;
            }

            actual = actual.Siguiente;
        }

        throw new KeyNotFoundException(
            $"SKU {sku} no encontrado."
        );
    }

    /// <summary>
    /// Actualiza un producto existente mediante su SKU.
    /// </summary>
    /// <param name="sku">SKU del producto que se desea actualizar.</param>
    /// <param name="productoActualizado">
    /// Nuevos datos del producto.
    /// </param>
    /// <returns>True si el producto fue actualizado; false si no existe.</returns>
    public bool ActualizarProducto(int sku, Producto productoActualizado)
    {
        NodoProducto? actual = _cabeza;

        while (actual != null)
        {
            if (actual.Data.SKU == sku)
            {
                actual.Data = productoActualizado;

                RegistrarAuditoria(
                    "UPDATE",
                    sku,
                    $"Producto '{productoActualizado.Nombre}' actualizado."
                );

                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    /// <summary>
    /// Elimina un producto mediante su SKU.
    /// </summary>
    /// <param name="sku">SKU del producto que se desea eliminar.</param>
    /// <returns>True si fue eliminado; false si no existe.</returns>
    public bool EliminarPorSKU(int sku)
    {
        if (_cabeza == null)
        {
            return false;
        }

        if (_cabeza.Data.SKU == sku)
        {
            string nombre = _cabeza.Data.Nombre;

            _cabeza = _cabeza.Siguiente;
            _totalProductos--;

            RegistrarAuditoria(
                "DELETE",
                sku,
                $"Producto '{nombre}' eliminado."
            );

            return true;
        }

        NodoProducto actual = _cabeza;

        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Data.SKU == sku)
            {
                string nombre = actual.Siguiente.Data.Nombre;

                actual.Siguiente = actual.Siguiente.Siguiente;
                _totalProductos--;

                RegistrarAuditoria(
                    "DELETE",
                    sku,
                    $"Producto '{nombre}' eliminado."
                );

                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    /// <summary>
    /// Recorre e imprime todos los productos de la lista.
    /// </summary>
    public void MostrarCatalogo()
    {
        if (_cabeza == null)
        {
            Console.WriteLine("El catálogo está vacío.");
            return;
        }

        NodoProducto? actual = _cabeza;

        while (actual != null)
        {
            Console.WriteLine(
                $"SKU: {actual.Data.SKU} | " +
                $"Nombre: {actual.Data.Nombre} | " +
                $"Precio: ${actual.Data.Precio:F2} | " +
                $"Stock: {actual.Data.Stock}"
            );

            actual = actual.Siguiente;
        }
    }

/// <summary>
/// Registra un evento en la bitácora después de una operación exitosa.
/// </summary>
private void RegistrarAuditoria(
    string tipoOperacion,
    int productoId,
    string referencia)
{
    LogMovimiento movimiento = new LogMovimiento
    {
        TipoOperacion = tipoOperacion,
        ProductoId = productoId,
        Referencia = referencia,
        FechaHora = DateTime.Now
    };

    _auditoria.RegistrarEvento(movimiento);
}

    /// <summary>
    /// Determina si el primer producto debe aparecer antes que el segundo.
    /// </summary>
    private static bool EsMenor(Producto a, Producto b)
    {
        if (a.Precio != b.Precio)
        {
            return a.Precio < b.Precio;
        }

        return a.SKU < b.SKU;
    }
}