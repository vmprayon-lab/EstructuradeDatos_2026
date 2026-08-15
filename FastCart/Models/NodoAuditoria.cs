namespace FastCart.Models;

/// <summary>
/// Representa un nodo de la lista doblemente enlazada de auditoría.
/// </summary>
public class NodoAuditoria
{
    /// <summary>
    /// Movimiento almacenado en el nodo.
    /// </summary>
    public LogMovimiento Dato;

    /// <summary>
    /// Referencia al siguiente nodo.
    /// </summary>
    public NodoAuditoria? Siguiente;

    /// <summary>
    /// Referencia al nodo anterior.
    /// </summary>
    public NodoAuditoria? Anterior;

    /// <summary>
    /// Inicializa un nodo con un movimiento de auditoría.
    /// </summary>
    /// <param name="dato">Movimiento que almacenará el nodo.</param>
    public NodoAuditoria(LogMovimiento dato)
    {
        Dato = dato;
        Siguiente = null;
        Anterior = null;
    }
}