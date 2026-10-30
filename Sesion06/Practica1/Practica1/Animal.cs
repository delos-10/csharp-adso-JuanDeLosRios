namespace Practica1;

public class Animal
{
    public string Nombre { get; }
    public Animal(string nombre) => Nombre = nombre;
    public virtual void HacerSonido() => Console.WriteLine($"{Nombre} hace un sonido.");
}

public class Perro : Animal
{
    public Perro(string nombre) : base(nombre) { }
    public override void HacerSonido() => Console.WriteLine($"{Nombre} dice: ¡Guau!");
}

public class Gato : Animal
{
    public Gato(string nombre) : base(nombre) { }
    public override void HacerSonido() => Console.WriteLine($"{Nombre} dice: ¡Miau!");
}