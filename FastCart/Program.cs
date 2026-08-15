using Fase1;
using Fase2;
using FastCart.Inventory;
using FastCart.Models;
using FastCart.Services;

namespace FastCart;

class Program
{
    static void Main()
    {
        AuditoriaService auditoria = new AuditoriaService();

        FastCart.Inventory.InventarioLista inventario =
            new FastCart.Inventory.InventarioLista(auditoria);

        ColaDespacho cola = new ColaDespacho();
        PilaDevoluciones pila = new PilaDevoluciones();

        bool ejecutando = true;

        while (ejecutando)
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║       FASTCART - MENÚ MAESTRO v4.0              ║");
            Console.WriteLine("╠══════════════════════════════════════════════════╣");
            Console.WriteLine("║ FASE 1 - ORDENAMIENTO                            ║");
            Console.WriteLine("║ [1] Demostrar ShellSort                         ║");
            Console.WriteLine("╠══════════════════════════════════════════════════╣");
            Console.WriteLine("║ FASE 2 - INVENTARIO                              ║");
            Console.WriteLine("║ [2] Agregar producto                             ║");
            Console.WriteLine("║ [3] Buscar producto por SKU                      ║");
            Console.WriteLine("║ [4] Eliminar producto por SKU                    ║");
            Console.WriteLine("║ [5] Mostrar catálogo                             ║");
            Console.WriteLine("╠══════════════════════════════════════════════════╣");
            Console.WriteLine("║ FASE 3 - BITÁCORA                                ║");
            Console.WriteLine("║ [6] Ver historial cronológico                    ║");
            Console.WriteLine("║ [7] Ver historial inverso                        ║");
            Console.WriteLine("╠══════════════════════════════════════════════════╣");
            Console.WriteLine("║ FASE 4 - COLA Y PILA                             ║");
            Console.WriteLine("║ [8] Encolar pedido                               ║");
            Console.WriteLine("║ [9] Despachar pedido (FIFO)                      ║");
            Console.WriteLine("║ [10] Registrar devolución                        ║");
            Console.WriteLine("║ [11] Procesar devolución (LIFO)                  ║");
            Console.WriteLine("║ [12] Ver estado de cola y pila                   ║");
            Console.WriteLine("╠══════════════════════════════════════════════════╣");
            Console.WriteLine("║ [0] SALIR                                        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");

            Console.Write("\nSeleccione una opción: ");
            string? opcion = Console.ReadLine();

            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    DemostrarShellSort();
                    Pausar();
                    break;

                case "2":
                    AgregarProducto(inventario);
                    Pausar();
                    break;

                case "3":
                    BuscarProducto(inventario);
                    Pausar();
                    break;

                case "4":
                    EliminarProducto(inventario);
                    Pausar();
                    break;

                case "5":
                    inventario.MostrarCatalogo();
                    Pausar();
                    break;

                case "6":
                    Console.WriteLine("=== HISTORIAL CRONOLÓGICO ===");
                    auditoria.ImprimirHistorial();
                    Pausar();
                    break;

                case "7":
                    Console.WriteLine("=== HISTORIAL INVERSO ===");
                    auditoria.ImprimirHistorialInverso();
                    Pausar();
                    break;

                case "8":
                    EncolarPedido(cola);
                    Pausar();
                    break;

                case "9":
                    DespacharPedido(
                        cola,
                        inventario,
                        auditoria
                    );
                    Pausar();
                    break;

                case "10":
                    RegistrarDevolucion(pila);
                    Pausar();
                    break;

                case "11":
                    ProcesarDevolucion(
                        pila,
                        inventario,
                        auditoria
                    );
                    Pausar();
                    break;

                case "12":
                    MostrarEstado(cola, pila);
                    Pausar();
                    break;

                case "0":
                    ejecutando = false;
                    Console.WriteLine("Saliendo de FastCart...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    Pausar();
                    break;
            }
        }
    }

    static void DemostrarShellSort()
    {
        Fase1.Producto[] productos =
        {
            new Fase1.Producto
            {
                SKU = 101,
                Nombre = "Laptop",
                Precio = 15000,
                Stock = 10
            },
            new Fase1.Producto
            {
                SKU = 102,
                Nombre = "Monitor",
                Precio = 5000,
                Stock = 20
            },
            new Fase1.Producto
            {
                SKU = 103,
                Nombre = "Teclado",
                Precio = 1500,
                Stock = 30
            },
            new Fase1.Producto
            {
                SKU = 104,
                Nombre = "Mouse",
                Precio = 1500,
                Stock = 40
            }
        };

        Console.WriteLine("=== FASE 1 - SHELLSORT ===");
        Console.WriteLine();
        Console.WriteLine("Antes del ordenamiento:");

        MostrarProductosFase1(productos);

        OrdenamientoService.ShellSort(productos);

        Console.WriteLine();
        Console.WriteLine("Después del ShellSort:");

        MostrarProductosFase1(productos);
    }

    static void MostrarProductosFase1(
        Fase1.Producto[] productos)
    {
        foreach (Fase1.Producto producto in productos)
        {
            Console.WriteLine(
                $"SKU: {producto.SKU} | " +
                $"Nombre: {producto.Nombre} | " +
                $"Precio: ${producto.Precio:F2} | " +
                $"Stock: {producto.Stock}"
            );
        }
    }

    static void AgregarProducto(
        FastCart.Inventory.InventarioLista inventario)
    {
        Console.WriteLine("=== AGREGAR PRODUCTO ===");

        int sku = LeerEntero("SKU: ");
        string nombre = LeerTexto("Nombre: ");
        double precio = LeerDouble("Precio: ");
        int stock = LeerEntero("Stock: ");

        Fase2.Producto producto = new Fase2.Producto
        {
            SKU = sku,
            Nombre = nombre,
            Precio = precio,
            Stock = stock
        };

        inventario.InsertarOrdenado(producto);

        Console.WriteLine("Producto agregado correctamente.");
    }

    static void BuscarProducto(
        FastCart.Inventory.InventarioLista inventario)
    {
        Console.WriteLine("=== BUSCAR PRODUCTO ===");

        int sku = LeerEntero("SKU: ");

        try
        {
            Fase2.Producto producto =
                inventario.BuscarPorSKU(sku);

            Console.WriteLine(
                $"SKU: {producto.SKU} | " +
                $"Nombre: {producto.Nombre} | " +
                $"Precio: ${producto.Precio:F2} | " +
                $"Stock: {producto.Stock}"
            );
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine(
                $"No se encontró el SKU {sku}."
            );
        }
    }

    static void EliminarProducto(
        FastCart.Inventory.InventarioLista inventario)
    {
        Console.WriteLine("=== ELIMINAR PRODUCTO ===");

        int sku = LeerEntero("SKU: ");

        bool eliminado =
            inventario.EliminarPorSKU(sku);

        Console.WriteLine(
            eliminado
                ? "Producto eliminado correctamente."
                : "No se encontró el producto."
        );
    }

    static void EncolarPedido(
        ColaDespacho cola)
    {
        Console.WriteLine("=== ENCOLAR PEDIDO ===");

        int idPedido = LeerEntero("ID del pedido: ");
        int sku = LeerEntero("SKU: ");
        int cantidad = LeerEntero("Cantidad: ");
        string cliente = LeerTexto("Cliente: ");

        Pedido pedido = new Pedido(
            idPedido,
            sku,
            cantidad,
            cliente
        );

        cola.EncolarPedido(pedido);

        Console.WriteLine(
            $"Pedido #{idPedido} encolado correctamente."
        );

        Console.WriteLine(
            $"Total en cola: {cola.TotalEncolados}"
        );
    }

    static void DespacharPedido(
        ColaDespacho cola,
        FastCart.Inventory.InventarioLista inventario,
        AuditoriaService auditoria)
    {
        Console.WriteLine("=== DESPACHAR PEDIDO FIFO ===");

        if (cola.EstaVacia)
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        Pedido? pedido = cola.DespacharPedido(
            inventario,
            auditoria
        );

        if (pedido == null)
        {
            Console.WriteLine(
                "El pedido no pudo ser despachado."
            );
            return;
        }

        Console.WriteLine(
            $"Pedido #{pedido.IdPedido} despachado correctamente."
        );

        Console.WriteLine(
            $"SKU: {pedido.SKU} | " +
            $"Cantidad: {pedido.Cantidad} | " +
            $"Cliente: {pedido.Cliente}"
        );
    }

    static void RegistrarDevolucion(
        PilaDevoluciones pila)
    {
        Console.WriteLine("=== REGISTRAR DEVOLUCIÓN ===");

        int idDevolucion =
            LeerEntero("ID de devolución: ");

        int sku = LeerEntero("SKU: ");
        int cantidad = LeerEntero("Cantidad: ");
        string motivo = LeerTexto("Motivo: ");

        Devolucion devolucion = new Devolucion(
            idDevolucion,
            sku,
            cantidad,
            motivo
        );

        pila.PushDevolucion(devolucion);

        Console.WriteLine(
            $"Devolución #{idDevolucion} registrada."
        );

        Console.WriteLine(
            $"Total en pila: {pila.TotalDevoluciones}"
        );
    }

    static void ProcesarDevolucion(
        PilaDevoluciones pila,
        FastCart.Inventory.InventarioLista inventario,
        AuditoriaService auditoria)
    {
        Console.WriteLine("=== PROCESAR DEVOLUCIÓN LIFO ===");

        if (pila.EstaVacia)
        {
            Console.WriteLine("La pila está vacía.");
            return;
        }

        Devolucion? devolucion =
            pila.PopDevolucion(
                inventario,
                auditoria
            );

        if (devolucion == null)
        {
            Console.WriteLine(
                "La devolución no pudo ser procesada."
            );
            return;
        }

        Console.WriteLine(
            $"Devolución #{devolucion.IdDevolucion} " +
            "procesada correctamente."
        );

        Console.WriteLine(
            $"SKU: {devolucion.SKU} | " +
            $"Cantidad: {devolucion.Cantidad} | " +
            $"Motivo: {devolucion.Motivo}"
        );
    }

    static void MostrarEstado(
        ColaDespacho cola,
        PilaDevoluciones pila)
    {
        Console.WriteLine("=== ESTADO DE ESTRUCTURAS ===");
        Console.WriteLine();

        Console.WriteLine(
            $"COLA FIFO: " +
            $"{cola.TotalEncolados} pedido(s)"
        );

        Console.WriteLine(
            cola.EstaVacia
                ? "Estado: VACÍA"
                : "Estado: CON PEDIDOS"
        );

        Console.WriteLine();

        Console.WriteLine(
            $"PILA LIFO: " +
            $"{pila.TotalDevoluciones} devolución(es)"
        );

        Console.WriteLine(
            pila.EstaVacia
                ? "Estado: VACÍA"
                : "Estado: CON DEVOLUCIONES"
        );
    }

    static int LeerEntero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);

            if (int.TryParse(
                Console.ReadLine(),
                out int valor))
            {
                return valor;
            }

            Console.WriteLine(
                "Ingrese un número entero válido."
            );
        }
    }

    static double LeerDouble(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);

            if (double.TryParse(
                Console.ReadLine(),
                out double valor))
            {
                return valor;
            }

            Console.WriteLine(
                "Ingrese un número válido."
            );
        }
    }

    static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);

            string? valor = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(valor))
            {
                return valor;
            }

            Console.WriteLine(
                "El campo no puede estar vacío."
            );
        }
    }

    static void Pausar()
    {
        Console.WriteLine();
        Console.WriteLine(
            "Presione ENTER para continuar..."
        );

        Console.ReadLine();
    }
}