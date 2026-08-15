using System.Diagnostics;

namespace Fase1;

class Program
{
    static void Main()
    {
        Producto[] catalogo = GenerarCatalogo(50);

        Console.WriteLine("CATÁLOGO ANTES DE ORDENAR");
        ImprimirCatalogo(catalogo);

        Stopwatch cronometro = Stopwatch.StartNew();

        OrdenamientoService.ShellSort(catalogo);

        cronometro.Stop();

        Console.WriteLine("\nCATÁLOGO DESPUÉS DE SHELLSORT");
        ImprimirCatalogo(catalogo);

        Console.WriteLine("\nVALIDACIÓN DEL ORDENAMIENTO");

        if (ValidarOrden(catalogo))
        {
            Console.WriteLine("✓ El catálogo está correctamente ordenado.");
        }
        else
        {
            Console.WriteLine("✗ El catálogo NO está correctamente ordenado.");
        }

        Console.WriteLine("\nBENCHMARK SHELLSORT");
        Console.WriteLine($"Productos procesados: {catalogo.Length}");
        Console.WriteLine($"Tiempo de ejecución: {cronometro.Elapsed.TotalMilliseconds:F4} ms");
    }

    static Producto[] GenerarCatalogo(int cantidad)
    {
        Producto[] catalogo = new Producto[cantidad];

        Random random = new Random(42);

        for (int i = 0; i < cantidad; i++)
        {
            catalogo[i] = new Producto
            {
                SKU = i + 1,
                Nombre = $"Producto {i + 1}",
                Precio = random.Next(100, 1001),
                Stock = random.Next(1, 101)
            };
        }

        return catalogo;
    }

    static void ImprimirCatalogo(Producto[] catalogo)
    {
        foreach (Producto producto in catalogo)
        {
            Console.WriteLine(
                $"SKU: {producto.SKU} | " +
                $"Nombre: {producto.Nombre} | " +
                $"Precio: ${producto.Precio} | " +
                $"Stock: {producto.Stock}"
            );
        }
    }

    static bool ValidarOrden(Producto[] catalogo)
    {
        for (int i = 1; i < catalogo.Length; i++)
        {
            if (catalogo[i - 1].Precio < catalogo[i].Precio)
            {
                return false;
            }

            if (catalogo[i - 1].Precio == catalogo[i].Precio &&
                catalogo[i - 1].SKU > catalogo[i].SKU)
            {
                return false;
            }
        }

        return true;
    }
}