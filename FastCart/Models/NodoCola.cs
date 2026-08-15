namespace FastCart.Models;

/// <summary>
/// Representa un nodo de la cola dinámica de pedidos.
/// </summary>
public class NodoCola
{
    /// <summary>
    /// Pedido almacenado en el nodo.
    /// </summary>
    public Pedido Data { get; set; }

    /// <summary>
    /// Referencia al siguiente nodo de la cola.
    /// </summary>
    public NodoCola? Siguiente { get; set; }

    /// <summary>
    /// Inicializa un nodo con un pedido.
    /// </summary>
    /// <param name="pedido">Pedido que almacenará el nodo.</param>
    public NodoCola(Pedido pedido)
    {
        Data = pedido;
        Siguiente = null;
    }
}