# Práctica 5: Sistema de Gestión de Inventario Básico

## Objetivo

Implementar un sistema básico de gestión de inventario en C# utilizando `struct`, arreglos, paso por referencia, validación de entradas y persistencia mediante archivos CSV.

## Funcionalidades

### Registro de productos

Cada producto contiene:

- ID
- Nombre
- Precio
- Stock

Los productos se almacenan en un arreglo de `Producto` con capacidad máxima de 10 registros.

### Mostrar inventario

El sistema muestra todos los productos registrados con su ID, nombre, precio y stock.

### Búsqueda por ID

Se realiza una búsqueda lineal dentro del arreglo para localizar un producto mediante su ID.

Si el producto existe, se muestran todos sus datos. Si no existe, se informa al usuario.

### Validación de entrada

Se utiliza `TryParse` para validar los valores numéricos de ID, precio y stock.

El sistema vuelve a solicitar el dato cuando la entrada no es válida.

### Actualización de stock

El usuario puede localizar un producto mediante su ID y modificar únicamente su cantidad de stock.

### Persistencia CSV

El inventario puede guardarse en `Inventario.csv` y posteriormente cargarse nuevamente.

El archivo utiliza el formato:

```text
ID,Nombre,Precio,Stock
101,Laptop HP,899.99,50
Pruebas realizadas

Se probó el registro de un producto:

ID    Nombre    Precio    Stock
101    Laptop HP    $899.99    25

También se probaron entradas inválidas para ID y precio.

La búsqueda por ID funcionó correctamente tanto para productos existentes como inexistentes.

El stock fue actualizado de 25 a 50 correctamente.

Finalmente, el inventario fue guardado y cargado desde Inventario.csv, recuperando correctamente ID, nombre, precio y stock.

Ejecución
dotnet build
dotnet run
Estructura
Semana5Inventario/
+-- Inventario.csv
+-- Producto.cs
+-- Program.cs
+-- README.md
+-- Semana5Inventario.csproj
Conclusión

La práctica permitió implementar un sistema de inventario utilizando struct, arreglos, validación con TryParse, búsqueda lineal, actualización de stock y persistencia mediante archivos CSV.

Las pruebas realizadas confirmaron el funcionamiento de las principales operaciones del sistema.
