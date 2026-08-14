using System;

namespace Semana4Recursividad
{
    public static class AlgoritmosIterativos
    {
        public static long FactorialIterativo(int n)
        {
            if (n < 0) throw new ArgumentException("n debe ser >= 0");

            long resultado = 1;

            for (int i = 2; i <= n; i++)
                resultado *= i;

            return resultado;
        }

        public static long FibonacciIterativo(int n)
        {
            if (n < 0) throw new ArgumentException("n debe ser >= 0");
            if (n == 0) return 0;
            if (n == 1) return 1;

            long anterior = 0;
            long actual = 1;

            for (int i = 2; i <= n; i++)
            {
                long siguiente = anterior + actual;
                anterior = actual;
                actual = siguiente;
            }

            return actual;
        }
    }
}
