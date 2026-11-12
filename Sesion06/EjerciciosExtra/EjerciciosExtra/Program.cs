
using EjerciciosExtra;

var cel = new Celular("Iphone", 20);
Console.WriteLine($"{cel.Marca} - Batería: {cel.Bateria}%");

cel.Cargar(80);
Console.WriteLine($"Después de cargar: {cel.Bateria}%");

Console.WriteLine($"¿Usó 20 min? {cel.Usar(20)} - {cel.Bateria}%");
Console.WriteLine($"¿Usó 70 min? {cel.Usar(70)} - {cel.Bateria}%");