using Fase2;
using FastCart.Inventory;
using FastCart.Services;

namespace FastCart;

class Program
{
    static void Main()
    {
        AuditoriaService auditoria = new AuditoriaService();
        FastCart.Inventory.InventarioLista inventario =
    new FastCart.Inventory.InventarioLista(auditoria);

        Producto producto1 = new Producto
        {
            SKU = 101,
            Nombre = "Laptop",
            Precio = 15000,
            Stock = 10
        };

        Producto producto2 = new Producto
        {
            SKU = 102,
            Nombre = "Monitor",
            Precio = 5000,
            Stock = 20
        };

        Console.WriteLine("=== FASE 3 - BITÁCORA DE AUDITORÍA ===");
        Console.WriteLine();

        Console.WriteLine("1. INSERTANDO PRODUCTOS...");
        inventario.InsertarOrdenado(producto1);
        inventario.InsertarOrdenado(producto2);

        Console.WriteLine("Productos insertados correctamente.");
        Console.WriteLine();

        Console.WriteLine("2. ACTUALIZANDO PRODUCTO...");
        Producto productoActualizado = new Producto
        {
            SKU = 101,
            Nombre = "Laptop Actualizada",
            Precio = 14500,
            Stock = 8
        };

        bool actualizado = inventario.ActualizarProducto(
            101,
            productoActualizado
        );

        Console.WriteLine(
            actualizado
                ? "SKU 101 actualizado correctamente."
                : "SKU 101 no encontrado."
        );

        Console.WriteLine();

        Console.WriteLine("3. ELIMINANDO PRODUCTO...");
        bool eliminado = inventario.EliminarPorSKU(102);

        Console.WriteLine(
            eliminado
                ? "SKU 102 eliminado correctamente."
                : "SKU 102 no encontrado."
        );

        Console.WriteLine();

        Console.WriteLine("=== CATÁLOGO FINAL ===");
        inventario.MostrarCatalogo();

        Console.WriteLine();

        Console.WriteLine("=== HISTORIAL CRONOLÓGICO ===");
        auditoria.ImprimirHistorial();

        Console.WriteLine();

        Console.WriteLine("=== HISTORIAL INVERSO ===");
        auditoria.ImprimirHistorialInverso();

        Console.WriteLine();

        Console.WriteLine(
            $"TOTAL DE REGISTROS DE AUDITORÍA: {auditoria.TotalRegistros}"
        );
    }
}