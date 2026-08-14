using System;

namespace Semana4Recursividad
{
    public static class AlgoritmosRecursivos
    {
        public static long FactorialRecursivo(int n)
        {
            if (n < 0) throw new ArgumentException("n debe ser >= 0");
            if (n <= 1) return 1;

            return n * FactorialRecursivo(n - 1);
        }

        public static long FibonacciRecursivo(int n)
        {
            if (n < 0) throw new ArgumentException("n debe ser >= 0");
            if (n == 0) return 0;
            if (n == 1) return 1;

            return FibonacciRecursivo(n - 1) + FibonacciRecursivo(n - 2);
        }
    }
}
