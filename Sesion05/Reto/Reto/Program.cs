using Reto;

List<Producto> inventario =
[
    new Producto("P001", "Teclado Mecánico", 180000m, 10),
    new Producto("P002", "Mouse Gamer", 95000m, 15),
    new Producto("P003", "Monitor 24 Pulgadas", 620000m, 5)
];

List<LineaVenta> carrito = [];
int consecutivoFactura = 1;
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n================ TIENDA ADSO ================");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender (agregar al carrito)");
    Console.WriteLine("4. Ver carrito con total");
    Console.WriteLine("5. Ver inventario");
    Console.WriteLine("6. Confirmar compra y generar factura (Extra)");
    Console.WriteLine("0. Salir");
    Console.Write("Selecciona una opción: ");

    string opcion = Console.ReadLine()?.Trim() ?? "";
    Console.WriteLine();

    switch (opcion)
    {
        case "1":
            try
            {
                Console.Write("Código: ");
                string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (inventario.Any(p => p.Codigo == codigo))
                {
                    Console.WriteLine("Error: Ya existe un producto con ese código.");
                    break;
                }

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine() ?? "";

                Console.Write("Precio: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
                {
                    Console.WriteLine("Error: Precio inválido.");
                    break;
                }

                Console.Write("Stock inicial: ");
                if (!int.TryParse(Console.ReadLine(), out int stock))
                {
                    Console.WriteLine("Error: Stock inválido.");
                    break;
                }

                var nuevo = new Producto(codigo, nombre, precio, stock);
                inventario.Add(nuevo);
                Console.WriteLine($"Producto registrado: {nuevo}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Producto rechazado: {ex.Message}");
            }
            break;

        case "2":
            Console.Write("Código del producto: ");
            string codStock = (Console.ReadLine() ?? "").Trim().ToUpper();
            var prodStock = inventario.FirstOrDefault(p => p.Codigo == codStock);

            if (prodStock is null)
            {
                Console.WriteLine("El producto no existe.");
                break;
            }

            Console.Write("Cantidad a agregar: ");
            if (int.TryParse(Console.ReadLine(), out int cantAgregar))
            {
                try
                {
                    prodStock.AgregarStock(cantAgregar);
                    Console.WriteLine($"Stock actualizado. Nuevo stock de {prodStock.Nombre}: {prodStock.Stock}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
            break;

        case "3":
            Console.Write("Código del producto a vender: ");
            string codVenta = (Console.ReadLine() ?? "").Trim().ToUpper();
            var prodVenta = inventario.FirstOrDefault(p => p.Codigo == codVenta);

            if (prodVenta is null)
            {
                Console.WriteLine("El producto no existe.");
                break;
            }

            Console.Write($"Cantidad a vender (Disponible: {prodVenta.Stock}): ");
            if (int.TryParse(Console.ReadLine(), out int cantVenta))
            {
                if (prodVenta.Vender(cantVenta))
                {
                    decimal subtotal = prodVenta.Precio * cantVenta;
                    carrito.Add(new LineaVenta(prodVenta.Codigo, prodVenta.Nombre, cantVenta, subtotal));
                    Console.WriteLine($"Agregado al carrito: {cantVenta}x {prodVenta.Nombre} (${subtotal:N2})");
                }
                else
                {
                    Console.WriteLine("Venta rechazada: cantidad inválida o stock insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
            break;

        case "4":
            if (carrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                Console.WriteLine("--- CARRITO DE COMPRAS ---");
                foreach (var linea in carrito)
                {
                    Console.WriteLine($"[{linea.Codigo}] {linea.Nombre,-20} | Cant: {linea.Cantidad,3} | Subtotal: ${linea.Subtotal,10:N2}");
                }
                decimal totalCarrito = carrito.Sum(l => l.Subtotal);
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"TOTAL CARRITO: ${totalCarrito:N2}");
            }
            break;

        case "5":
            Console.WriteLine("--- INVENTARIO ACTUAL ---");
            foreach (var p in inventario)
            {
                Console.WriteLine(p);
            }
            break;

        case "6":
            if (carrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                break;
            }

            decimal totalFactura = carrito.Sum(l => l.Subtotal);
            var factura = new Factura(
                $"FAC-{consecutivoFactura++:D3}",
                DateTime.Now,
                carrito.ToList(),
                totalFactura
            );

            Console.WriteLine("=============================================");
            Console.WriteLine($"RECIBO DE COMPRA · {factura.Numero}");
            Console.WriteLine($"Fecha: {factura.Fecha:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine("---------------------------------------------");
            foreach (var item in factura.Lineas)
            {
                Console.WriteLine($"{item.Cantidad}x {item.Nombre,-22} ${item.Subtotal,12:N2}");
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"TOTAL A PAGAR:             ${factura.Total,12:N2}");
            Console.WriteLine("=============================================");

            carrito.Clear();
            break;

        case "0":
            salir = true;
            Console.WriteLine("¡Hasta luego!");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

public record LineaVenta(string Codigo, string Nombre, int Cantidad, decimal Subtotal);
public record Factura(string Numero, DateTime Fecha, List<LineaVenta> Lineas, decimal Total);