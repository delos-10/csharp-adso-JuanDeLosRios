
using Vehiculos;

//Console.WriteLine("Hello, World!");



//Console.WriteLine(new Carro("abc123", 5));
//Console.WriteLine(new Cohete("hkl42ld",0));
//Console.WriteLine(new Moto("aoo48H"));

List<Vehiculo> fila =
    [
        new Carro("abc123", 5),
        new Cohete("hkl42ld",0),
        new Moto("aoo48H"),
        new CarroElectrico("ele001", 4),
        new CarroElectrico("ele081", 6)
    ];

foreach (Vehiculo v in fila)
    Console.WriteLine(v.Describir());

Console.WriteLine($"Total recaudado: {fila.Sum(v => v.CalcularPeaje()):C0}");

foreach (Vehiculo v in fila)
{
    if (v is IRecargable r)
        Console.WriteLine($"{v.Placa} tiene {r.Bateria}% de batería");
}

List<IRecargable> enchufados = [
    new CarroElectrico("elect932", 2), new Patineta()];

CargarTodos(enchufados);

static void CargarTodos(List<IRecargable> lista)
{
    foreach (IRecargable dispositivo in lista)
    {
        dispositivo.Recargar();
        Console.WriteLine($"{dispositivo.GetType().Name}: {dispositivo.Bateria}%");
    }
}
