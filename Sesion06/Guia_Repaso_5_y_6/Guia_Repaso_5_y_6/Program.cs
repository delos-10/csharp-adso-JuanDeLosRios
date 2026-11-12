using Guia_Repaso_5_y_6;

// 1. Crear los objetos usando el constructor (new)
Libro libro1 = new Libro("Cien años de soledad", "Gabriel García Márquez", 471);
Libro libro2 = new Libro("La vorágine", "José Eustasio Rivera", 320);

// 2. Imprimir el estado inicial (usará el ToString que creaste)
Console.WriteLine("--- ESTADO INICIAL ---");
Console.WriteLine(libro1);
Console.WriteLine(libro2);

// 3. Probar el comportamiento (los métodos)
Console.WriteLine("\n--- PRÉSTAMO ---");
bool exito = libro1.Prestar();
if (exito)
{
    Console.WriteLine($"Se prestó con éxito: {libro1.Titulo}");
}

// 4. Ver cómo cambiaron los datos de libro1, pero no los de libro2
Console.WriteLine("\n--- ESTADO FINAL ---");
Console.WriteLine(libro1);
Console.WriteLine(libro2);






//List<Libro> libreria =
//    [
//    new Libro("La odisea", "homero", 720),
//    new Libro("La voargine", "jose eustasio rivera", 320),
//    new Libro("Don quijote", "Miguel cervantes", 120)
//    ];
//var disponible = libreria.Where(Libro => Libro.Disponible).ToList();

//var maslargo = libreria.MaxBy(l => l.Paginas);
//Console.WriteLine($"el mas largo es {maslargo.Titulo}");
