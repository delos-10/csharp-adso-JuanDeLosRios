using System.ComponentModel;

Console.WriteLine("Hello, World!");


//Crear una lista

List<string> compras = ["Arroz", "Leche", "frijol", "Leche"];

Console.WriteLine($"Tienes antes de agregar  {compras.Count} elementos");

compras.Add("café"); //permite agregar a una lista

Console.WriteLine($"Tienes despues de agregar de agregar  {compras.Count} elementos");

//compras.Remove("Leche"); //permite eli{minar un elemento

Console.WriteLine(string.Join(", ", compras));

compras.Sort(); //ordena la lista

Console.WriteLine(string.Join(", ", compras));


Console.WriteLine("======================");
//crear un diccionario

Dictionary<string, string> agenda = new(StringComparer.OrdinalIgnoreCase);

agenda["Anna"] = "3001234567";
agenda["Luis"] = "3154444444";


if (agenda.TryGetValue("Ana", out string? telefono ))
{
    Console.WriteLine($"Ana: {telefono}");

}

foreach(var (nombre, tel)in agenda)
{
    Console.WriteLine($"{nombre}: {tel}");
}

Console.WriteLine("=======================");

//diccionario con listas adentro 

Dictionary<string, List<double>> notas = new(StringComparer.OrdinalIgnoreCase);
notas["Miguel"] = [];
notas["Miguel"].Add(4.5);
notas["Miguel"].Add(3.8);
notas["Miguel"].Add(1);

foreach (var (nombre, nota) in notas)
{
    Console.WriteLine($"{nombre}: {string.Join(" - ", nota)}");
}


Console.WriteLine("=====================");

List<int> numeros = [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

var pares = numeros.Where(numeros => numeros % 2 == 0).ToList();

Console.WriteLine(string.Join(", ", numeros));
Console.WriteLine(string.Join(", ", pares));

var top3 = numeros.OrderByDescending(n => n).Take(3).ToList();
Console.WriteLine(string.Join(", ", top3));

Console.WriteLine($"Suma: {numeros.Sum()} · Promedio: {numeros.Average():N1}");

Console.WriteLine($"¿Alguno mayor a 80? {(numeros.Any(n => n > 80) ? "Sí hay" : "No hay")}");


Console.WriteLine("=========================================");

// record

List<Producto> productos =
[
    new("Cuaderno", "Papelería", 6500m, 40),
    new("Mouse", "Tecnología", 45000m, 3),
    new("USB 64 GB", "Tecnología", 38000m, 15)
];

var baratos = productos.Where(p => p.Precio < 10000m);
var masCaro = productos.MaxBy(p => p.Precio);
var masCaro1 = productos.Max(p => p.Precio);
decimal valorInventario = productos.Sum(p => p.Precio * p.Stock);

Console.WriteLine($"Menores a 10000\n{string.Join("\n", baratos)}");
Console.WriteLine($"MAS CARO - nombre {masCaro}");
Console.WriteLine($"MAS CARO - nombre {masCaro1}"); 
Console.WriteLine($"Valor inventario {valorInventario}");



 var porCategoria = productos
    .GroupBy(p => p.Categoria)
    .Select(g => new { Categoria = g.Key, Unidades = g.Sum(p => p.Stock) });

foreach (var c in porCategoria)
{
    Console.WriteLine($"{c.Categoria,-12} {c.Unidades} unidades");
}

 record Producto(string Nombre, string Categoria, decimal Precio, int Stock);



   


