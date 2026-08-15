namespace FastCart.Models;

/// <summary>
/// Representa un movimiento registrado en la bitácora de auditoría.
/// </summary>
public struct LogMovimiento
{
    public string TipoOperacion;
    public int ProductoId;
    public string Referencia;
    public DateTime FechaHora;
}