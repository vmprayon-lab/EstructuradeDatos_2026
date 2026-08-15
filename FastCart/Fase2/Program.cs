namespace Fase2;

class Program
{
    static void Main()
    {
        InventarioLista inventario = new InventarioLista();
        Producto productoInicio = new Producto
{
    SKU = 99,
    Nombre = "Producto Inicio",
    Precio = 50,
    Stock = 5
};

inventario.InsertarInicio(productoInicio);

        Producto[] productos =
        {
            new Producto { SKU = 1, Nombre = "Producto 1", Precio = 500, Stock = 10 },
            new Producto { SKU = 2, Nombre = "Producto 2", Precio = 200, Stock = 20 },
            new Producto { SKU = 3, Nombre = "Producto 3", Precio = 800, Stock = 15 },
            new Producto { SKU = 4, Nombre = "Producto 4", Precio = 100, Stock = 30 },
            new Producto { SKU = 5, Nombre = "Producto 5", Precio = 300, Stock = 25 },
            new Producto { SKU = 6, Nombre = "Producto 6", Precio = 700, Stock = 12 },
            new Producto { SKU = 7, Nombre = "Producto 7", Precio = 400, Stock = 18 },
            new Producto { SKU = 8, Nombre = "Producto 8", Precio = 600, Stock = 22 },
            new Producto { SKU = 9, Nombre = "Producto 9", Precio = 150, Stock = 14 },
            new Producto { SKU = 10, Nombre = "Producto 10", Precio = 900, Stock = 8 },
            new Producto { SKU = 11, Nombre = "Producto 11", Precio = 250, Stock = 16 },
            new Producto { SKU = 12, Nombre = "Producto 12", Precio = 350, Stock = 19 },
            new Producto { SKU = 13, Nombre = "Producto 13", Precio = 750, Stock = 11 },
            new Producto { SKU = 14, Nombre = "Producto 14", Precio = 450, Stock = 21 },
            new Producto { SKU = 15, Nombre = "Producto 15", Precio = 550, Stock = 13 }
        };

        Console.WriteLine("INSERTANDO 15 PRODUCTOS...");

        foreach (Producto producto in productos)
        {
            inventario.InsertarOrdenado(producto);
        }

        Console.WriteLine();
        Console.WriteLine("CATÁLOGO DESPUÉS DE LAS INSERCIONES");
        Console.WriteLine("--------------------------------");

        inventario.MostrarCatalogo();

        Console.WriteLine();
        Console.WriteLine($"TOTAL DE PRODUCTOS: {inventario.TotalProductos}");

        Console.WriteLine();
        Console.WriteLine("PRUEBA DE BÚSQUEDA");

        try
        {
            Producto encontrado = inventario.BuscarPorSKU(8);

            Console.WriteLine(
                $"Encontrado: SKU {encontrado.SKU} - " +
                $"{encontrado.Nombre} - " +
                $"Precio ${encontrado.Precio:F2}"
            );
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("PRUEBA DE SKU INEXISTENTE");

        try
        {
            inventario.BuscarPorSKU(999);
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Excepción controlada: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("PRUEBA DE ELIMINACIÓN");

        bool eliminado = inventario.EliminarPorSKU(8);

        Console.WriteLine(
            eliminado
                ? "SKU 8 eliminado correctamente."
                : "SKU 8 no fue encontrado."
        );

        Console.WriteLine();
        Console.WriteLine("CATÁLOGO DESPUÉS DE ELIMINAR SKU 8");
        Console.WriteLine("--------------------------------");

        inventario.MostrarCatalogo();

        Console.WriteLine();
        Console.WriteLine($"TOTAL FINAL: {inventario.TotalProductos}");
    }
}