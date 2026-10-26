List<Venta> ventas =
[
    new("Portátil", "Medellín", 2, 2_800_000m),
    new("Mouse", "Bogotá", 10, 45_000m),
    new("Teclado", "Cali", 5, 120_000m),
    new("Monitor", "Medellín", 3, 750_000m),
    new("Mouse", "Medellín", 8, 45_000m),
    new("Portátil", "Bogotá", 1, 2_800_000m),
    new("Diadema", "Cali", 6, 180_000m),
    new("Monitor", "Bogotá", 2, 750_000m),
    new("Teclado", "Medellín", 4, 120_000m),
    new("Diadema", "Bogotá", 3, 180_000m),
    new("Portátil", "Cali", 2, 2_800_000m),
    new("Mouse", "Cali", 12, 45_000m)
];

decimal totalVendido = ventas.Sum(v => v.Cantidad * v.PrecioUnitario);

decimal promedioVenta = ventas.Average(v => v.Cantidad * v.PrecioUnitario);

Console.WriteLine("=== REPORTE DE VENTAS ===");

Console.WriteLine("Total vendido: $" + totalVendido.ToString("N0"));
Console.WriteLine("Promedio por venta: $" + promedioVenta.ToString("N2"));

Console.WriteLine("\n=== VENTAS POR CIUDAD ===");

var ventasCiudad = ventas
    .GroupBy(v => v.Ciudad)
    .Select(g => new
    {
        Ciudad = g.Key,
        Total = g.Sum(v => v.Cantidad * v.PrecioUnitario)
    })
    .OrderByDescending(v => v.Total);

foreach (var ciudad in ventasCiudad)
{
    Console.WriteLine(ciudad.Ciudad + ": $" + ciudad.Total.ToString("N0"));
}

Console.WriteLine("\n=== TOP 3 PRODUCTOS POR INGRESOS ===");

var topProductos = ventas
    .GroupBy(v => v.Producto)
    .Select(g => new
    {
        Producto = g.Key,
        Ingresos = g.Sum(v => v.Cantidad * v.PrecioUnitario)
    })
    .OrderByDescending(p => p.Ingresos)
    .Take(3);

foreach (var producto in topProductos)
{
    Console.WriteLine(producto.Producto + ": $" + producto.Ingresos.ToString("N0"));
}

Console.WriteLine("\n=== PRODUCTO MAS VENDIDO ===");

var masVendido = ventas
    .GroupBy(v => v.Producto)
    .Select(g => new
    {
        Producto = g.Key,
        Unidades = g.Sum(v => v.Cantidad)
    })
    .OrderByDescending(p => p.Unidades)
    .First();

Console.WriteLine(masVendido.Producto + ": " + masVendido.Unidades + " unidades");

record Venta(string Producto, string Ciudad, int Cantidad, decimal PrecioUnitario);