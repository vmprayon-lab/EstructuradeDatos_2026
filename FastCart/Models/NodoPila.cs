namespace FastCart.Models;

/// <summary>
/// Representa un nodo de la pila dinámica de devoluciones.
/// </summary>
public class NodoPila
{
    /// <summary>
    /// Devolución almacenada en el nodo.
    /// </summary>
    public Devolucion Data { get; set; }

    /// <summary>
    /// Referencia al siguiente nodo de la pila.
    /// </summary>
    public NodoPila? Siguiente { get; set; }

    /// <summary>
    /// Inicializa un nodo con una devolución.
    /// </summary>
    /// <param name="devolucion">Devolución que almacenará el nodo.</param>
    public NodoPila(Devolucion devolucion)
    {
        Data = devolucion;
        Siguiente = null;
    }
}