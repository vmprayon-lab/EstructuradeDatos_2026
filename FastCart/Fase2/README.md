# FastCart - Fase 2

## Lista enlazada dinámica del catálogo

En esta fase se reemplaza el manejo estático del catálogo mediante arreglos por una estructura de datos dinámica basada en una lista simplemente enlazada.

## Estructura

- `Producto.cs`: modelo de producto.
- `NodoProducto.cs`: nodo que almacena un producto y referencia al siguiente nodo.
- `InventarioLista.cs`: administra la lista enlazada.
- `Program.cs`: demostración y pruebas funcionales.

## Operaciones implementadas

- `InsertarInicio()`
- `InsertarOrdenado()`
- `BuscarPorSKU()`
- `EliminarPorSKU()`
- `MostrarCatalogo()`

### Inserción ordenada

Los productos insertados mediante `InsertarOrdenado()` se mantienen en orden ascendente por precio.

En caso de empate de precio, se utiliza el SKU como criterio secundario.

### Búsqueda

`BuscarPorSKU()` realiza un recorrido lineal de la lista.

Cuando el SKU no existe, se genera una `KeyNotFoundException` controlada.

### Eliminación

`EliminarPorSKU()` permite eliminar productos de la cabeza, posiciones intermedias o final de la lista, conservando los enlaces restantes.

## Pruebas realizadas

La demostración ejecuta:

1. Inserción de 15 productos mediante `InsertarOrdenado()`.
2. Inserción adicional mediante `InsertarInicio()`.
3. Validación del catálogo mediante recorrido.
4. Búsqueda de un SKU existente.
5. Búsqueda de un SKU inexistente.
6. Eliminación de un producto.
7. Verificación del total de elementos después de la eliminación.

Resultado de la prueba:

```text
TOTAL DE PRODUCTOS: 16
SKU 8 encontrado correctamente
SKU 999 genera excepción controlada
SKU 8 eliminado correctamente
TOTAL FINAL: 15

Comparación con Fase 1

En la Fase 1 el catálogo se manejó mediante un arreglo y posteriormente se utilizó ShellSort para ordenar los productos.

En la Fase 2 se utiliza una lista enlazada, permitiendo agregar y eliminar nodos dinámicamente sin depender de un arreglo de tamaño fijo.

La lista enlazada tiene como ventaja la flexibilidad para escenarios donde el número de productos cambia con frecuencia. Como contraparte, las búsquedas y recorridos requieren avanzar nodo por nodo, por lo que tienen costo O(n).

Ejecución

Desde la carpeta Fase2:

dotnet build
dotnet run