using Tarea;

ProcesadorPagos procesador = new();

IMetodoPago efectivo = new PagoEfectivo();
IMetodoPago tarjetaValida = new PagoTarjeta("4532015112830366");
IMetodoPago tarjetaInvalida = new PagoTarjeta("12345"); // Menos de 16 dígitos
IMetodoPago billetera = new PagoBilletera();

Console.WriteLine("=== PRUEBAS DE COBRO ===");
procesador.Cobrar(efectivo, 150_000m);
procesador.Cobrar(tarjetaValida, 500_000m);
procesador.Cobrar(tarjetaInvalida, 500_000m);
procesador.Cobrar(billetera, 1_500_000m);
procesador.Cobrar(billetera, 2_500_000m); // Supera el tope de $2.000.000

Console.WriteLine("\n=== PRUEBAS DE REEMBOLSO ===");
procesador.Devolver(efectivo, 150_000m);
procesador.Devolver(tarjetaValida, 500_000m);
procesador.Devolver(billetera, 1_500_000m);