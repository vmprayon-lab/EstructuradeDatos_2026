using FastCart.Models;

namespace FastCart.Services;

/// <summary>
/// Administra la bitácora de auditoría mediante una lista
/// doblemente enlazada.
/// </summary>
public class AuditoriaService
{
    private NodoAuditoria? _cabeza;
    private NodoAuditoria? _cola;

    /// <summary>
    /// Obtiene la cantidad total de registros de auditoría.
    /// </summary>
    public int TotalRegistros { get; private set; }

    /// <summary>
    /// Inicializa una bitácora vacía.
    /// </summary>
    public AuditoriaService()
    {
        _cabeza = null;
        _cola = null;
        TotalRegistros = 0;
    }

    /// <summary>
    /// Registra un nuevo evento al final de la bitácora.
    /// </summary>
    /// <param name="movimiento">
    /// Movimiento que se agregará al historial.
    /// </param>
    public void RegistrarEvento(LogMovimiento movimiento)
    {
        NodoAuditoria nuevo = new NodoAuditoria(movimiento);

        if (_cabeza == null)
        {
            _cabeza = nuevo;
            _cola = nuevo;
        }
        else
        {
            nuevo.Anterior = _cola;
            _cola!.Siguiente = nuevo;
            _cola = nuevo;
        }

        TotalRegistros++;
    }

    /// <summary>
    /// Imprime el historial desde el evento más antiguo
    /// hasta el más reciente.
    /// </summary>
    public void ImprimirHistorial()
    {
        NodoAuditoria? actual = _cabeza;

        while (actual != null)
        {
            ImprimirMovimiento(actual.Dato);
            actual = actual.Siguiente;
        }
    }

    /// <summary>
    /// Imprime el historial desde el evento más reciente
    /// hasta el más antiguo.
    /// </summary>
    public void ImprimirHistorialInverso()
    {
        NodoAuditoria? actual = _cola;

        while (actual != null)
        {
            ImprimirMovimiento(actual.Dato);
            actual = actual.Anterior;
        }
    }

    /// <summary>
    /// Imprime un movimiento de auditoría.
    /// </summary>
    private static void ImprimirMovimiento(LogMovimiento movimiento)
    {
        Console.WriteLine(
            $"{movimiento.FechaHora:yyyy-MM-dd HH:mm:ss} | " +
            $"{movimiento.TipoOperacion} | " +
            $"SKU: {movimiento.ProductoId} | " +
            $"{movimiento.Referencia}"
        );
    }
}