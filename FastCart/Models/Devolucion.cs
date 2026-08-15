namespace FastCart.Models;

/// <summary>
/// Representa una devolución registrada en el sistema.
/// </summary>
public class Devolucion
{
    public int IdDevolucion { get; set; }
    public int SKU { get; set; }
    public int Cantidad { get; set; }
    public string Motivo { get; set; }

    public Devolucion(
        int idDevolucion,
        int sku,
        int cantidad,
        string motivo)
    {
        IdDevolucion = idDevolucion;
        SKU = sku;
        Cantidad = cantidad;
        Motivo = motivo;
    }
}
