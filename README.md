# Práctica 2: Simulación de Punteros en C#

**Nombre:** Víctor Manuel Péres Rayón  
**Matrícula:** 333009283

## Descripción

Este proyecto corresponde a la Práctica 2 de la materia de Algoritmos y Estructuras de Datos.

El objetivo es refactorizar una calculadora de cinemática utilizando los modificadores `ref` y `out` en C#. El programa permite calcular velocidad, distancia y tiempo mediante métodos que utilizan paso por referencia.

## Estructura del proyecto

```text
EstructuradeDatos_2026/
├── src/
│   ├── Program.cs
│   ├── Operaciones.cs
│   ├── EntradaUsuario.cs
│   └── CalculadoraFisica.csproj
├── capturas/
│   ├── 01_rama_creada.png
│   ├── 02_codigo_ref.png
│   ├── 03_codigo_out.png
│   ├── 04_refactor_semana1.png
│   ├── 05_commits_git.png
│   └── 06_merge_final.png
├── README.md
└── .gitignore
Operaciones
Calcular velocidad: v = d / t
Calcular distancia: d = v * t
Calcular tiempo: t = d / v
Tecnologías utilizadas
C#
.NET
Git
GitHub
Cómo compilar y ejecutar
Abrir una terminal en la carpeta raíz del repositorio.
Compilar el proyecto:
dotnet build ./src/CalculadoraFisica.csproj
Ejecutar la aplicación:
dotnet run --project ./src/CalculadoraFisica.csproj
Seleccionar una de las opciones disponibles:
1 Calcular velocidad
2 Calcular distancia
3 Calcular tiempo
0 Salir
Uso de ref y out

El método CalcularVelocidad utiliza el modificador ref para modificar una variable existente mediante referencia.

Los métodos CalcularDistancia y CalcularTiempo utilizan el modificador out para producir sus respectivos resultados dentro del método.

Flujo de Git

Para el desarrollo de esta práctica se utilizó la rama:

feature/referencias

Se realizaron commits intermedios para documentar el proceso de refactorización. Posteriormente, la rama feature/referencias fue integrada mediante un merge a main.

Reflexión personal

Durante esta práctica comprendí mejor la diferencia entre el paso por valor y el paso por referencia en C#. Aprendí que ref permite modificar una variable existente, mientras que out permite obtener valores generados dentro de un método. También reforcé el uso de Git mediante ramas, commits intermedios y merge. Finalmente, comprobé que estos conceptos pueden aplicarse a un programa funcional sin utilizar punteros directamente.