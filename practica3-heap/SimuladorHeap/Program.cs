using System;

class SimuladorHeap
{
    // MAIN: punto de entrada
    static void Main(string[] args)
    {
        Console.Write("¿Cuántos elementos? ");
        int n = int.Parse(Console.ReadLine()!);

        // La REFERENCIA 'arreglo' vive en el Stack
        // El OBJETO arreglo vive en el Heap
        string[] arreglo = InicializarArreglo(n);

        Console.WriteLine("\n--- Arreglo Inicial ---");
        MostrarArreglo(arreglo);

        // Pasamos la referencia a la función modificadora
        ModificarArreglo(arreglo);

        // Escenario A: modificar elementos
        ModificarElementos(arreglo);

        Console.WriteLine("\n--- Antes de Reasignar ---");
        MostrarArreglo(arreglo);

        // Escenario B: reasignar la referencia local
        ReasignarArreglo(arreglo);

        Console.WriteLine("\n--- Después de Reasignar ---");
        MostrarArreglo(arreglo);
    }

    // Crea y retorna una nueva referencia al Heap
    static string[] InicializarArreglo(int n)
    {
        string[] temp = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Elemento [{i}]: ");
            temp[i] = Console.ReadLine()!;
        }

        return temp;
    }

    // Recibe la referencia y trabaja sobre
    // el MISMO objeto en el Heap
    static void ModificarArreglo(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            // Se crea un nuevo objeto string en el Heap
            // y se actualiza la referencia en arr[i]
            arr[i] = arr[i].ToUpper() + $" [MOD-{i}]";
        }
    }

    // Solo lee la referencia, no modifica
    static void MostrarArreglo(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($" [{i}] = {arr[i]}");
        }
    }

    // Escenario A: modifica el contenido del objeto en el Heap
    static void ModificarElementos(string[] arr)
    {
        // Los cambios se ven desde Main
        arr[0] = "MODIFICADO";
    }

    // Escenario B: reasigna solamente la referencia local
    static void ReasignarArreglo(string[] arr)
    {
        // Crea un NUEVO objeto en el Heap
        // pero solo cambia la referencia local
        arr = new string[] { "NUEVO", "ARREGLO" };
    }
}