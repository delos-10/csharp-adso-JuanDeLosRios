using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

var servicio = new ServicioInventario(new RepositorioJson("inventario.json"));
// Nivel extra: para probar en memoria sin archivos, descomenta la siguiente línea:
// var servicio = new ServicioInventario(new RepositorioMemoria());

bool salir = false;

while (!salir)
{
    Console.WriteLine("\n=== SISTEMA DE INVENTARIO ===");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender producto");
    Console.WriteLine("4. Ver inventario");
    Console.WriteLine("5. Ver stock bajo (< 5)");
    Console.WriteLine("6. Buscar producto por texto");
    Console.WriteLine("7. Eliminar producto");
    Console.WriteLine("0. Salir");
    Console.Write("Selecciona una opción: ");

    string opcion = Console.ReadLine()?.Trim() ?? "";
    Console.WriteLine();

    try
    {
        switch (opcion)
        {
            case "1":
                RegistrarProducto(servicio);
                break;
            case "2":
                AgregarStockProducto(servicio);
                break;
            case "3":
                VenderProducto(servicio);
                break;
            case "4":
                MostrarLista(servicio.Listar(), "INVENTARIO COMPLETO");
                break;
            case "5":
                MostrarLista(servicio.StockBajo(), "PRODUCTOS CON STOCK BAJO (< 5)");
                break;
            case "6":
                BuscarProducto(servicio);
                break;
            case "7":
                EliminarProducto(servicio);
                break;
            case "0":
                salir = true;
                Console.WriteLine("Saliendo del sistema...");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
    catch (StockInsuficienteException ex)
    {
        Console.WriteLine($"[Alerta de Stock]: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"[Datos inválidos]: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[Error inesperado]: {ex.Message}");
    }
}

static void RegistrarProducto(ServicioInventario servicio)
{
    Console.Write("Código: ");
    string codigo = Console.ReadLine() ?? "";

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine() ?? "";

    Console.Write("Precio: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
    {
        Console.WriteLine("Debes ingresar un precio numérico válido.");
        return;
    }

    Console.Write("Stock inicial: ");
    if (!int.TryParse(Console.ReadLine(), out int stock))
    {
        Console.WriteLine("Debes ingresar una cantidad entera válida.");
        return;
    }

    servicio.Agregar(new Producto(codigo, nombre, precio, stock));
    Console.WriteLine("Producto registrado correctamente.");
}

static void AgregarStockProducto(ServicioInventario servicio)
{
    Console.Write("Código del producto: ");
    string codigo = Console.ReadLine() ?? "";

    Console.Write("Cantidad a sumar: ");
    if (!int.TryParse(Console.ReadLine(), out int cantidad))
    {
        Console.WriteLine("Debes ingresar un número entero válido.");
        return;
    }

    servicio.AgregarStock(codigo, cantidad);
    Console.WriteLine("Stock actualizado correctamente.");
}

static void VenderProducto(ServicioInventario servicio)
{
    Console.Write("Código del producto: ");
    string codigo = Console.ReadLine() ?? "";

    Console.Write("Cantidad a vender: ");
    if (!int.TryParse(Console.ReadLine(), out int cantidad))
    {
        Console.WriteLine("Debes ingresar un número entero válido.");
        return;
    }

    servicio.Vender(codigo, cantidad);
    Console.WriteLine("Venta realizada con éxito.");
}

static void MostrarLista(List<Producto> productos, string titulo)
{
    Console.WriteLine($"--- {titulo} ---");
    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos para mostrar.");
        return;
    }

    foreach (var p in productos)
    {
        Console.WriteLine(p);
    }
}

static void BuscarProducto(ServicioInventario servicio)
{
    Console.Write("Texto a buscar (nombre o código): ");
    string texto = Console.ReadLine() ?? "";

    var resultados = servicio.BuscarPorTexto(texto);
    MostrarLista(resultados, $"RESULTADOS PARA '{texto}'");
}

static void EliminarProducto(ServicioInventario servicio)
{
    Console.Write("Código del producto a eliminar: ");
    string codigo = Console.ReadLine()?.Trim() ?? "";

    Console.Write($"¿Estás seguro de eliminar el producto '{codigo}'? (s/n): ");
    string confirmacion = Console.ReadLine()?.Trim().ToLower() ?? "";

    if (confirmacion == "s")
    {
        servicio.Eliminar(codigo);
        Console.WriteLine("Producto eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("Eliminación cancelada.");
    }
}
