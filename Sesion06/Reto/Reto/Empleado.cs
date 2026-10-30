namespace Reto;

public interface IBonificable
{
    decimal CalcularBono();
}

public abstract class Empleado
{
    public string Nombre { get; }
    public string Documento { get; }
    public virtual string Tipo => "Empleado";

    protected Empleado(string nombre, string documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    public abstract decimal CalcularSalario();

    public override string ToString() =>
        $"[{Tipo}] {Nombre} (Doc: {Documento}) -> Pago: ${CalcularSalario():N0}";
}

public class EmpleadoPlanta : Empleado, IBonificable
{
    public decimal SalarioMensual { get; }
    public int AniosAntiguedad { get; }
    public override string Tipo => "Planta";

    public EmpleadoPlanta(string nombre, string documento, decimal salarioMensual, int aniosAntiguedad)
        : base(nombre, documento)
    {
        SalarioMensual = salarioMensual;
        AniosAntiguedad = aniosAntiguedad;
    }

    public decimal CalcularBono() => AniosAntiguedad >= 5 ? SalarioMensual * 0.05m : 0m;

    public override decimal CalcularSalario() => SalarioMensual + CalcularBono();
}

public class EmpleadoPorHoras : Empleado
{
    public int Horas { get; }
    public decimal ValorHora { get; }
    public override string Tipo => "Por Horas";

    public EmpleadoPorHoras(string nombre, string documento, int horas, decimal valorHora)
        : base(nombre, documento)
    {
        Horas = horas;
        ValorHora = valorHora;
    }

    public override decimal CalcularSalario()
    {
        if (Horas <= 160)
            return Horas * ValorHora;

        int horasExtra = Horas - 160;
        return (160 * ValorHora) + (horasExtra * ValorHora * 1.5m);
    }
}

public class Contratista : Empleado
{
    public decimal ValorContrato { get; }
    public override string Tipo => "Contratista";

    public Contratista(string nombre, string documento, decimal valorContrato)
        : base(nombre, documento)
    {
        ValorContrato = valorContrato;
    }

    public override decimal CalcularSalario() => ValorContrato * 0.90m;
}