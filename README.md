# Práctica 2: Simulación de Punteros en C#
**Nombre:** Víctor Manuel Péres Rayón
**Matrícula:** 333009283

## Descripción
Este proyecto corresponde a la Práctica 2 de la materia de Algoritmos y Estructuras de Datos. El objetivo es refactorizar una calculadora de cinemática desarrollada previamente, utilizando los modificadores `ref` y `out` en C# para realizar el paso por referencia.

El proyecto contiene operaciones para calcular velocidad, distancia y tiempo, utilizando `ref` para modificar valores existentes y `out` para obtener resultados directamente desde los métodos.

## Operaciones

- **Calcular velocidad:** `v = d / t`
- **Calcular distancia:** `d = v * t`
- **Calcular tiempo:** `t = d / v`

## Tecnologías utilizadas

- C#
- .NET
- Git
- GitHub

## Cómo compilar y ejecutar

1. Abrir una terminal en la carpeta del proyecto.
2. Ejecutar:

```
dotnet build
```

3. Para ejecutar la aplicación:

```
dotnet run
```

4. Seleccionar una de las opciones disponibles en el menú:
   - `1` Calcular velocidad
   - `2` Calcular distancia
   - `3` Calcular tiempo
   - `0` Salir

## Uso de ref y out
El método `CalcularVelocidad` utiliza `ref` para modificar directamente la variable que recibe como referencia.

Los métodos `CalcularDistancia` y `CalcularTiempo` utilizan `out` para generar sus respectivos resultados dentro del método.

## Flujo de Git
Para el desarrollo de esta práctica se utilizó la rama:

```
feature/referencias
```
Se realizaron commits intermedios para documentar el proceso de refactorización y posteriormente se integraron los cambios a `main`.

## Reflexión personal
Durante esta práctica comprendí mejor la diferencia entre el paso por valor y el paso por referencia en C#. Aprendí que `ref` permite modificar una variable existente, mientras que `out` permite obtener valores generados dentro de un método. También reforcé el uso de Git mediante ramas, commits intermedios y merge. Finalmente, comprobé que estos conceptos pueden aplicarse a un programa funcional sin necesidad de utilizar punteros directamente.
