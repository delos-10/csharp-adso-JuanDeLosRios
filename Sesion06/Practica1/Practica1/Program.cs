using Practica1;

Console.WriteLine("=== PASO 1: HERENCIA CON ANIMALES ===");
List<Animal> animales =
[
    new Animal("Criatura"),
    new Perro("Firulais"),
    new Gato("Michi")
];

foreach (Animal animal in animales)
{
    animal.HacerSonido();
}

Console.WriteLine("\n=== PASOS 2 Y 3: CLASES ABSTRACTAS (FIGURAS) ===");
List<Figura> figuras =
[
    new Circulo(5),
    new Rectangulo(4, 8),
    new Triangulo(6),
    new Circulo(3.5),
    new Rectangulo(10, 9)
];

foreach (Figura figura in figuras)
{
    Console.WriteLine(figura);
}

Figura? mayor = figuras.MaxBy(f => f.Area());
Console.WriteLine($"\nFigura de mayor área -> {mayor}");