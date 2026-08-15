namespace Fase2;

/// <summary>
/// Representa un nodo de la lista enlazada de productos.
/// </summary>
public class NodoProducto
{
    /// <summary>
    /// Producto almacenado en el nodo.
    /// </summary>
    public Producto Data;

    /// <summary>
    /// Referencia al siguiente nodo de la lista.
    /// </summary>
    public NodoProducto? Siguiente;

    /// <summary>
    /// Inicializa un nodo con un producto.
    /// </summary>
    /// <param name="producto">Producto que almacenará el nodo.</param>
    public NodoProducto(Producto producto)
    {
        Data = producto;
        Siguiente = null;
    }
}