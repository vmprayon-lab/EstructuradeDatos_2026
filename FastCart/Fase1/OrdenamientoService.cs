namespace Fase1;

/// <summary>
/// Proporciona el algoritmo ShellSort para ordenar el catálogo.
/// </summary>
public static class OrdenamientoService
{
    /// <summary>
    /// Ordena los productos por precio descendente.
    /// En caso de empate, ordena por SKU ascendente.
    /// </summary>
    /// <param name="catalogo">Arreglo de productos a ordenar.</param>
    public static void ShellSort(Producto[] catalogo)
    {
        int n = catalogo.Length;

        // Secuencia de Knuth: 1, 4, 13, 40...
        int gap = 1;

        while (gap < n / 3)
        {
            gap = gap * 3 + 1;
        }

        while (gap >= 1)
        {
            for (int i = gap; i < n; i++)
            {
                Producto temporal = catalogo[i];
                int j = i;

                // Precio DESC y SKU ASC como desempate.
                while (j >= gap && EsMayor(catalogo[j - gap], temporal))
                {
                    catalogo[j] = catalogo[j - gap];
                    j -= gap;
                }

                catalogo[j] = temporal;
            }

            gap /= 3;
        }
    }

    /// <summary>
    /// Determina si el producto A debe colocarse después del producto B.
    /// </summary>
    private static bool EsMayor(Producto a, Producto b)
    {
        if (a.Precio != b.Precio)
        {
            // Precio descendente.
            return a.Precio < b.Precio;
        }

        // En empate de precio: SKU ascendente.
        return a.SKU > b.SKU;
    }
}
