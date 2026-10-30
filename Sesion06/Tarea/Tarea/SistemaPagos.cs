namespace Tarea;

public interface IMetodoPago
{
    string Nombre { get; }
    decimal CalcularComision(decimal monto);
    bool Validar(decimal monto);
}

public interface IReembolsable
{
    void Reembolsar(decimal monto);
}

public class PagoEfectivo : IMetodoPago
{
    public string Nombre => "Efectivo";

    public decimal CalcularComision(decimal monto) => 0m;

    public bool Validar(decimal monto) => monto > 0;
}

public class PagoTarjeta : IMetodoPago, IReembolsable
{
    public string Nombre => "Tarjeta";
    public string NumeroTarjeta { get; }

    public PagoTarjeta(string numeroTarjeta) => NumeroTarjeta = numeroTarjeta;

    public decimal CalcularComision(decimal monto) => monto * 0.03m;

    public bool Validar(decimal monto) =>
        monto > 0 && NumeroTarjeta.Length == 16 && NumeroTarjeta.All(char.IsDigit);

    public void Reembolsar(decimal monto) =>
        Console.WriteLine($"[Reembolso Tarjeta] Se devolvieron ${monto:N0} a la tarjeta terminada en {NumeroTarjeta[^4..]}.");
}

public class PagoBilletera : IMetodoPago, IReembolsable
{
    public string Nombre => "Billetera Digital";

    public decimal CalcularComision(decimal monto) => monto * 0.01m;

    public bool Validar(decimal monto) => monto > 0 && monto <= 2_000_000m;

    public void Reembolsar(decimal monto) =>
        Console.WriteLine($"[Reembolso Billetera] Se abonaron ${monto:N0} de vuelta a la billetera digital.");
}

public class ProcesadorPagos
{
    public void Cobrar(IMetodoPago metodo, decimal monto)
    {
        Console.WriteLine($"\nProcesando cobro de ${monto:N0} con {metodo.Nombre}...");

        if (!metodo.Validar(monto))
        {
            Console.WriteLine($"Pago rechazado: validación fallida para {metodo.Nombre}.");
            return;
        }

        decimal comision = metodo.CalcularComision(monto);
        decimal total = monto + comision;
        Console.WriteLine($"Pago aprobado | Monto: ${monto:N0} | Comisión: ${comision:N0} | Total: ${total:N0}");
    }

    public void Devolver(IMetodoPago metodo, decimal monto)
    {
        Console.WriteLine($"\nSolicitando devolución de ${monto:N0} en {metodo.Nombre}...");

        if (metodo is IReembolsable reembolsable)
        {
            reembolsable.Reembolsar(monto);
        }
        else
        {
            Console.WriteLine($"El método de pago '{metodo.Nombre}' no permite reembolsos.");
        }
    }
}