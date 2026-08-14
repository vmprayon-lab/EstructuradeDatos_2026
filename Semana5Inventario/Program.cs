using System;
using System.IO;
using System.Globalization;

namespace Semana5Inventario
{
    class Program
    {
        const int CAPACIDAD = 10;
        const string ARCHIVO_CSV = "Inventario.csv";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Producto[] inventario = new Producto[CAPACIDAD];
            int totalRegistros = 0;
            string opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("+------------------------------------------+");
                Console.WriteLine("�       SISTEMA DE GESTI�N DE INVENTARIO   �");
                Console.WriteLine("�------------------------------------------�");
                Console.WriteLine("� 1. Registrar producto                    �");
                Console.WriteLine("� 2. Mostrar productos                     �");
                Console.WriteLine("� 3. Salir                                 �");
                Console.WriteLine("� 4. Buscar producto por ID                �");
                Console.WriteLine("� 5. Actualizar stock                      �");
                Console.WriteLine("� 6. Guardar inventario                    �");
                Console.WriteLine("� 7. Cargar inventario                     �");
                Console.WriteLine("+------------------------------------------+");

                Console.Write("\nSelecciona una opci�n: ");
                opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        RegistrarProducto(inventario, ref totalRegistros, CAPACIDAD);
                        break;

                    case "2":
                        MostrarProductos(inventario, totalRegistros);
                        break;

                    case "3":
                        Console.WriteLine("\nCerrando sistema...");
                        break;

                    case "4":
                        BuscarProducto(inventario, totalRegistros);
                        break;

                    case "5":
                        ActualizarStock(inventario, totalRegistros);
                        break;

                    case "6":
                        GuardarInventario(inventario, totalRegistros);
                        break;

                    case "7":
                        CargarInventario(inventario, ref totalRegistros);
                        break;

                    default:
                        Console.WriteLine("\n[!] Opci�n no v�lida.");
                        Console.ReadLine();
                        break;
                }

            } while (opcion != "3");
        }

        static void RegistrarProducto(
            Producto[] inventario,
            ref int total,
            int capacidad)
        {
            Console.Clear();

            if (total >= capacidad)
            {
                Console.WriteLine("[!] El inventario est� lleno.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("-- REGISTRAR PRODUCTO --\n");

            int id;
            bool valido;

            do
            {
                Console.Write("ID del producto: ");
                valido = int.TryParse(Console.ReadLine(), out id);

                if (!valido || id <= 0)
                {
                    Console.WriteLine("[!] Ingresa un ID num�rico v�lido.");
                    valido = false;
                }

            } while (!valido);

            string nombre;

            do
            {
                Console.Write("Nombre: ");
                nombre = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("[!] El nombre no puede estar vac�o.");
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            double precio;

            do
            {
                Console.Write("Precio: $");
                valido = double.TryParse(Console.ReadLine(), out precio);

                if (!valido || precio < 0)
                {
                    Console.WriteLine("[!] Ingresa un precio v�lido.");
                    valido = false;
                }

            } while (!valido);

            int stock;

            do
            {
                Console.Write("Stock: ");
                valido = int.TryParse(Console.ReadLine(), out stock);

                if (!valido || stock < 0)
                {
                    Console.WriteLine("[!] Ingresa un stock v�lido.");
                    valido = false;
                }

            } while (!valido);

            inventario[total].ID = id;
            inventario[total].Nombre = nombre;
            inventario[total].Precio = precio;
            inventario[total].Stock = stock;

            total++;

            Console.WriteLine($"\n[?] Producto registrado. Total: {total}");
            Console.ReadLine();
        }

        static void MostrarProductos(
            Producto[] inventario,
            int total)
        {
            Console.Clear();

            if (total == 0)
            {
                Console.WriteLine("[!] No hay productos registrados.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("-- INVENTARIO --\n");

            Console.WriteLine(
                "{0,-6}{1,-25}{2,12}{3,8}",
                "ID",
                "Nombre",
                "Precio",
                "Stock");

            Console.WriteLine(new string('-', 51));

            for (int i = 0; i < total; i++)
            {
                Console.WriteLine(
                    "{0,-6}{1,-25}${2,10:F2}{3,8}",
                    inventario[i].ID,
                    inventario[i].Nombre,
                    inventario[i].Precio,
                    inventario[i].Stock);
            }

            Console.WriteLine($"\nTotal: {total} producto(s)");
            Console.ReadLine();
        }

        static void BuscarProducto(
            Producto[] inventario,
            int total)
        {
            Console.Clear();

            Console.WriteLine("-- BUSCAR PRODUCTO --\n");

            int idBuscado;
            bool valido;

            do
            {
                Console.Write("Ingresa el ID a buscar: ");
                valido = int.TryParse(Console.ReadLine(), out idBuscado);

                if (!valido || idBuscado <= 0)
                {
                    Console.WriteLine("[!] Ingresa un ID num�rico v�lido.");
                    valido = false;
                }

            } while (!valido);

            bool encontrado = false;

            for (int i = 0; i < total; i++)
            {
                if (inventario[i].ID == idBuscado)
                {
                    Console.WriteLine("\n[?] Producto encontrado:\n");
                    Console.WriteLine($"ID:     {inventario[i].ID}");
                    Console.WriteLine($"Nombre: {inventario[i].Nombre}");
                    Console.WriteLine($"Precio: ${inventario[i].Precio:F2}");
                    Console.WriteLine($"Stock:  {inventario[i].Stock}");

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine(
                    $"\n[!] No se encontr� un producto con ID {idBuscado}.");
            }

            Console.ReadLine();
        }

        static void ActualizarStock(
            Producto[] inventario,
            int total)
        {
            Console.Clear();

            Console.WriteLine("-- ACTUALIZAR STOCK --\n");

            int idBuscado;
            bool valido;

            do
            {
                Console.Write("Ingresa el ID del producto: ");
                valido = int.TryParse(Console.ReadLine(), out idBuscado);

                if (!valido || idBuscado <= 0)
                {
                    Console.WriteLine("[!] Ingresa un ID num�rico v�lido.");
                    valido = false;
                }

            } while (!valido);

            for (int i = 0; i < total; i++)
            {
                if (inventario[i].ID == idBuscado)
                {
                    Console.WriteLine(
                        $"Producto: {inventario[i].Nombre}");

                    Console.WriteLine(
                        $"Stock actual: {inventario[i].Stock}");

                    int nuevoStock;

                    do
                    {
                        Console.Write("Nuevo stock: ");
                        valido = int.TryParse(
                            Console.ReadLine(),
                            out nuevoStock);

                        if (!valido || nuevoStock < 0)
                        {
                            Console.WriteLine(
                                "[!] Ingresa un stock v�lido.");
                            valido = false;
                        }

                    } while (!valido);

                    inventario[i].Stock = nuevoStock;

                    Console.WriteLine(
                        "\n[?] Stock actualizado correctamente.");

                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine(
                $"\n[!] No se encontr� un producto con ID {idBuscado}.");

            Console.ReadLine();
        }

        static void GuardarInventario(
            Producto[] inventario,
            int total)
        {
            try
            {
                string[] lineas = new string[total + 1];

                lineas[0] = "ID,Nombre,Precio,Stock";

                for (int i = 0; i < total; i++)
                {
                    lineas[i + 1] =
                        $"{inventario[i].ID}," +
                        $"{inventario[i].Nombre}," +
                        $"{inventario[i].Precio}," +
                        $"{inventario[i].Stock}";
                }

                File.WriteAllLines(ARCHIVO_CSV, lineas);

                Console.WriteLine(
                    $"\n[?] Inventario guardado correctamente en {ARCHIVO_CSV}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"\n[!] Error al guardar: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void CargarInventario(
            Producto[] inventario,
            ref int total)
        {
            Console.Clear();

            if (!File.Exists(ARCHIVO_CSV))
            {
                Console.WriteLine(
                    $"[!] No existe el archivo {ARCHIVO_CSV}.");
                Console.ReadLine();
                return;
            }

            try
            {
                string[] lineas = File.ReadAllLines(ARCHIVO_CSV);

                total = 0;

                for (int i = 1; i < lineas.Length && total < CAPACIDAD; i++)
                {
                    string[] datos = lineas[i].Split(',');

                    if (datos.Length != 4)
                    {
                        continue;
                    }

                    if (!int.TryParse(datos[0], out int id))
                    {
                        continue;
                    }

                    if (!double.TryParse(datos[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double precio))
                    {
                        continue;
                    }

                    if (!int.TryParse(datos[3], out int stock))
                    {
                        continue;
                    }

                    inventario[total].ID = id;
                    inventario[total].Nombre = datos[1];
                    inventario[total].Precio = precio;
                    inventario[total].Stock = stock;

                    total++;
                }

                Console.WriteLine(
                    $"\n[?] Inventario cargado correctamente.");
                Console.WriteLine(
                    $"Productos cargados: {total}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"\n[!] Error al cargar: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
