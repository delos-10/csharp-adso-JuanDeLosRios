using Tarea;

CuentaBancaria cuenta1 = new CuentaBancaria("Juan De Los Rios", "001", 200000m);
CuentaBancaria cuenta2 = new CuentaBancaria("Ricardo", "002");

Console.WriteLine("--- Estado inicial ---");
Console.WriteLine(cuenta1);
Console.WriteLine(cuenta2);

Console.WriteLine("\n--- Operaciones ---");
Console.WriteLine($"Depósito $50.000 a Juan: {cuenta1.Depositar(50000m)}");
Console.WriteLine($"Retiro $500.000 a Juan (supera saldo): {cuenta1.Retirar(500000m)}");
Console.WriteLine($"Retiro -$10.000 a Juan (monto negativo): {cuenta1.Retirar(-10000m)}");
Console.WriteLine($"Transferencia $80.000 de Juan a Ricardo: {cuenta1.Transferir(cuenta2, 80000m)}");

Console.WriteLine("\n--- Estado final ---");
Console.WriteLine(cuenta1);
Console.WriteLine(cuenta2);