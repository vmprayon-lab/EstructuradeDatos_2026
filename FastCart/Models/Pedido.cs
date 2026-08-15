namespace FastCart.Models;

/// <summary>
/// Representa un pedido pendiente de despacho.
/// </summary>
public class Pedido
{
    public int IdPedido { get; set; }
    public int SKU { get; set; }
    public int Cantidad { get; set; }
    public string Cliente { get; set; }

    public Pedido(
        int idPedido,
        int sku,
        int cantidad,
        string cliente)
    {
        IdPedido = idPedido;
        SKU = sku;
        Cantidad = cantidad;
        Cliente = cliente;
    }
}