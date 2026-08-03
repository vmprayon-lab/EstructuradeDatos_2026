namespace CalculadoraFisica;

using System.Globalization;

static class EntradaUsuario
{
    /// <summary>
    /// Solicita un número decimal al usuario con validación robusta.
    /// Reintenta hasta recibir un valor válido.
    /// </summary>
    /// <param name="mensaje">Mensaje que se muestra al usuario.</param>
    /// <param name="soloPositivos">
    /// Si es true, solo acepta valores mayores que cero.
    /// </param>
    /// <returns>Valor decimal validado.</returns>
    public static double PedirDouble(
        string mensaje,
        bool soloPositivos = true)
    {
        while (true)
        {
            Console.Write(mensaje);

            string entrada = Console.ReadLine() ?? "";

            if (double.TryParse(
                    entrada,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double resultado))
            {
                if (soloPositivos && resultado <= 0)
                {
                    Console.WriteLine(
                        "El valor debe ser mayor que cero.\n");
                    continue;
                }

                return resultado;
            }

            Console.WriteLine(
                "Entrada inválida. Intente nuevamente.\n");
        }
    }
}