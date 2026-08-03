namespace CalculadoraFisica;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding =
            System.Text.Encoding.UTF8;

        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();

            string opcion =
                Console.ReadLine() ?? "0";

            continuar =
                ProcesarOpcion(opcion);
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();

        Console.WriteLine("==================================");
        Console.WriteLine("     CALCULADORA DE CINEMÁTICA");
        Console.WriteLine("==================================");
        Console.WriteLine("1. Calcular velocidad");
        Console.WriteLine("2. Calcular distancia");
        Console.WriteLine("3. Calcular tiempo");
        Console.WriteLine("0. Salir");
        Console.Write("\nElige una opción: ");
    }

    static bool ProcesarOpcion(string opcion)
    {
        Console.WriteLine();

        switch (opcion.Trim())
        {
            case "1":

                double distanciaMetros =
                    EntradaUsuario.PedirDouble(
                        "Distancia (m): ");

                double tiempoSegundos =
                    EntradaUsuario.PedirDouble(
                        "Tiempo (s): ");

                double velocidad =
                    Calculos.CalcularVelocidad(
                        distanciaMetros,
                        tiempoSegundos);

                Console.WriteLine(
                    $"\nVelocidad = {velocidad:F2} m/s");
                break;

            case "2":

                double velocidadMs =
                    EntradaUsuario.PedirDouble(
                        "Velocidad (m/s): ");

                double tiempoDistancia =
                    EntradaUsuario.PedirDouble(
                        "Tiempo (s): ");

                double distancia =
                    Calculos.CalcularDistancia(
                        velocidadMs,
                        tiempoDistancia);

                Console.WriteLine(
                    $"\nDistancia = {distancia:F2} m");
                break;

            case "3":

                double distanciaTiempo =
                    EntradaUsuario.PedirDouble(
                        "Distancia (m): ");

                double velocidadTiempo =
                    EntradaUsuario.PedirDouble(
                        "Velocidad (m/s): ");

                double tiempo =
                    Calculos.CalcularTiempo(
                        distanciaTiempo,
                        velocidadTiempo);

                Console.WriteLine(
                    $"\nTiempo = {tiempo:F2} s");
                break;

            case "0":

                Console.WriteLine("\n¡Hasta luego!");
                return false;

            default:

                Console.WriteLine(
                    "Opción no válida.");
                break;
        }

        Console.WriteLine(
            "\nPresiona ENTER para continuar...");
        Console.ReadLine();

        return true;
    }
}