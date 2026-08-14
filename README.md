# Práctica 4: Implementación Segura de Recursividad en C#

## Objetivo

Implementar y comparar algoritmos iterativos y recursivos para Factorial y Fibonacci, utilizando `Stopwatch` para medir su rendimiento y Git para versionar cada etapa del desarrollo.

## Algoritmos implementados

### Factorial

- Factorial iterativo: complejidad temporal O(n) y espacial O(1).
- Factorial recursivo: utiliza un caso base `n <= 1`.
- Ambos métodos producen el mismo resultado para Factorial(20).

### Fibonacci

- Fibonacci iterativo: complejidad temporal O(n) y espacial O(1).
- Fibonacci recursivo: utiliza los casos base `n == 0` y `n == 1`.
- El Fibonacci recursivo sin memoización tiene complejidad O(2^n).

## Resultados de la prueba

La prueba se realizó utilizando `nFactorial = 20` y `nFibonacci = 40`.

| Algoritmo | Método | Resultado | Tiempo |
|---|---|---:|---:|
| Factorial(20) | Iterativo | 2432902008176640000 | 0.263100 ms |
| Factorial(20) | Recursivo | 2432902008176640000 | 0.204200 ms |
| Fibonacci(40) | Iterativo | 102334155 | 0.160200 ms |
| Fibonacci(40) | Recursivo | 102334155 | 1461.174000 ms |

## Análisis

Los resultados obtenidos muestran que ambos métodos calculan correctamente los valores de Factorial y Fibonacci.

En Factorial(20), los tiempos fueron similares. Sin embargo, en Fibonacci(40) existe una diferencia considerable: el método iterativo tardó 0.160200 ms, mientras que el método recursivo tardó 1461.174000 ms.

Esto demuestra el costo de la complejidad exponencial O(2^n) del Fibonacci recursivo sin memoización. Aunque la recursividad puede ser más sencilla de expresar, puede resultar mucho menos eficiente cuando el número de llamadas crece.

## Caso base y Stack Overflow

El caso base es fundamental en una función recursiva porque detiene la cadena de llamadas.

En Factorial se utiliza:

`if (n <= 1) return 1;`

En Fibonacci se utilizan:

`if (n == 0) return 0;`

`if (n == 1) return 1;`

La ausencia de un caso base alcanzable puede provocar un Stack Overflow. La práctica señala que `StackOverflowException` no puede ser interceptada mediante un bloque `try/catch` convencional, por lo que la prevención es fundamental.

## Conclusión

La comparación demuestra que el enfoque iterativo resulta más eficiente para Fibonacci en esta prueba. La recursividad permite una implementación clara y elegante, pero requiere controlar correctamente el caso base y considerar su costo computacional.

## Historial de Git

1. `feat: scaffold proyecto Semana4Recursividad`
2. `feat: factorial y fibonacci iterativos - linea base O(n)`
3. `feat: factorial y fibonacci recursivos con caso base explicito`
4. `test: harness comparativo con System.Diagnostics.Stopwatch`
5. `docs: reporte de tiempos y analisis iterativo vs recursivo`

## Comando de ejecución

```bash
dotnet run