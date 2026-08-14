namespace CalculadoraFisica;
/// <summary>
/// Módulo de cálculos físicos de cinemática.
/// Todas las funciones son puras: mismo input = mismo output.
/// </summary>
static class Calculos
{
    // TODO: Migrar CalcularVelocidad para usar ref.
    // TODO: Migrar CalcularDistancia para usar out.
    // TODO: Migrar CalcularTiempo para usar out.
/// <summary>Calcula velocidad: v = d / t</summary>
/// <param name="distanciaMetros">Distancia en metros</param>
/// <param name="tiempoSegundos">Tiempo en segundos (> 0)</param>
/// <returns>Velocidad en metros por segundo</returns>
public static void CalcularVelocidad(
ref double velocidad,
double distanciaMetros,
double tiempoSegundos)
{
velocidad = distanciaMetros / tiempoSegundos;
}
/// <summary>Calcula distancia: d = v * t</summary>
public static void CalcularDistancia(
    double velocidadMs,
    double tiempoSegundos,
    out double distancia)
{
    distancia = velocidadMs * tiempoSegundos;
}/// <summary>Calcula tiempo: t = d / v</summary>
public static void CalcularTiempo(
    double distanciaMetros,
    double velocidadMs,
    out double tiempo)
{
    tiempo = distanciaMetros / velocidadMs;
}
}