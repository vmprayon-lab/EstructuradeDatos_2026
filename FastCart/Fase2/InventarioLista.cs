namespace Fase2;

/// <summary>
/// Administra el catálogo mediante una lista simplemente enlazada.
/// </summary>
public class InventarioLista
{
    private NodoProducto? _cabeza;
    private int _totalProductos;

    /// <summary>
    /// Obtiene la cantidad total de productos registrados.
    /// </summary>
    public int TotalProductos => _totalProductos;

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
            return;
        }

        if (EsMenor(producto, _cabeza.Data))
        {
            nuevo.Siguiente = _cabeza;
            _cabeza = nuevo;
            _totalProductos++;
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
            _cabeza = _cabeza.Siguiente;
            _totalProductos--;
            return true;
        }

        NodoProducto actual = _cabeza;

        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Data.SKU == sku)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                _totalProductos--;
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

    private static bool EsMenor(Producto a, Producto b)
    {
        if (a.Precio != b.Precio)
        {
            return a.Precio < b.Precio;
        }

        return a.SKU < b.SKU;
    }
}