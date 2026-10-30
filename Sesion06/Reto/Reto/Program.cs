using Reto;

List<Empleado> nomina =
[
    new EmpleadoPlanta("Ana Gómez", "1001", 3_200_000m, 6),      // 3.200.000 + 160.000 = 3.360.000
    new EmpleadoPlanta("Luis Pérez", "1002", 2_800_000m, 2),     // 2.800.000
    new EmpleadoPorHoras("Marta Ruiz", "1003", 170, 18_000m),    // (160*18.000) + (10*27.000) = 3.150.000
    new EmpleadoPorHoras("Jorge Díaz", "1004", 120, 18_000m),    // 120 * 18.000 = 2.160.000
    new Contratista("Sofía León", "1005", 4_000_000m)            // 4.000.000 - 10% = 3.600.000
];

Console.WriteLine("=== NÓMINA DE EMPLEADOS ===");
foreach (Empleado emp in nomina)
{
    Console.WriteLine(emp);
}

decimal totalNomina = nomina.Sum(e => e.CalcularSalario());
Empleado? mayorPago = nomina.MaxBy(e => e.CalcularSalario());

Console.WriteLine($"\nTotal Nómina: ${totalNomina:N0}");
Console.WriteLine($"Mayor Pago:   {mayorPago?.Nombre} (${mayorPago?.CalcularSalario():N0})");

Console.WriteLine("\n=== TOTAL POR TIPO (LINQ) ===");
var totalesPorTipo = nomina
    .GroupBy(e => e.Tipo)
    .Select(g => new { Tipo = g.Key, Total = g.Sum(e => e.CalcularSalario()), Cantidad = g.Count() });

foreach (var grupo in totalesPorTipo)
{
    Console.WriteLine($"- {grupo.Tipo} ({grupo.Cantidad}): ${grupo.Total:N0}");
}

//  Nivel extra: IBonificable con OfType
decimal totalBonos = nomina.OfType<IBonificable>().Sum(b => b.CalcularBono());
Console.WriteLine($"\n Total en bonos de antigüedad (IBonificable): ${totalBonos:N0}");