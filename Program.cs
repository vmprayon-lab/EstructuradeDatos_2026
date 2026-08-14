using System;
using System.Diagnostics;

namespace Semana4Recursividad
{
    class Program
    {
        static void Main()
        {
            int nFactorial = 20;
            int nFibonacci = 40;

            var sw = new Stopwatch();

            Console.WriteLine("==============================================");
            Console.WriteLine("     COMPARATIVA: ITERATIVO vs RECURSIVO");
            Console.WriteLine("==============================================");

            Console.WriteLine();
            Console.WriteLine($"--- FACTORIAL({nFactorial}) ---");

            sw.Restart();
            long resultFactIter = AlgoritmosIterativos.FactorialIterativo(nFactorial);
            sw.Stop();
            Console.WriteLine($"[Iterativo] Resultado: {resultFactIter} Tiempo: {sw.Elapsed.TotalMilliseconds:F6} ms");

            sw.Restart();
            long resultFactRec = AlgoritmosRecursivos.FactorialRecursivo(nFactorial);
            sw.Stop();
            Console.WriteLine($"[Recursivo] Resultado: {resultFactRec} Tiempo: {sw.Elapsed.TotalMilliseconds:F6} ms");

            Console.WriteLine();
            Console.WriteLine($"--- FIBONACCI({nFibonacci}) ---");

            sw.Restart();
            long resultFibIter = AlgoritmosIterativos.FibonacciIterativo(nFibonacci);
            sw.Stop();
            Console.WriteLine($"[Iterativo] Resultado: {resultFibIter} Tiempo: {sw.Elapsed.TotalMilliseconds:F6} ms");

            sw.Restart();
            long resultFibRec = AlgoritmosRecursivos.FibonacciRecursivo(nFibonacci);
            sw.Stop();
            Console.WriteLine($"[Recursivo] Resultado: {resultFibRec} Tiempo: {sw.Elapsed.TotalMilliseconds:F6} ms");

            Console.WriteLine();
            Console.WriteLine("[OK] Prueba completada.");
        }
    }
}
