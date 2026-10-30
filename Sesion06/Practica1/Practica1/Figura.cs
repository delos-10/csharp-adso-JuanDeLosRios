namespace Practica1;

public abstract class Figura
{
    public string Nombre { get; }
    protected Figura(string nombre) => Nombre = nombre;
    public abstract double Area();
    public override string ToString() => $"{Nombre}: área {Area():N2}";
}

public class Circulo : Figura
{
    public double Radio { get; }
    public Circulo(double radio) : base("Círculo") => Radio = radio;
    public override double Area() => Math.PI * Radio * Radio;
}

public class Rectangulo : Figura
{
    public double Base { get; }
    public double Altura { get; }

    public Rectangulo(double @base, double altura) : base("Rectángulo")
    {
        Base = @base;
        Altura = altura;
    }

    public override double Area() => Base * Altura;
}

public class Triangulo : Figura
{
    public double Lado { get; }
    public Triangulo(double lado) : base("Triángulo Equilátero") => Lado = lado;
    public override double Area() => (Math.Sqrt(3) / 4) * Lado * Lado;
}