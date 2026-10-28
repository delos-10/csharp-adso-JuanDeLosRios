Console.WriteLine("Hello, World!");


// PARTE 1 · CLASES Y OBJETOS (LIBRO

Console.WriteLine("=== PARTE 1: BIBLIOTECA ===");

List<Libro> biblioteca =
[
    new Libro("Cien años de soledad", "Gabriel García Márquez", 1967),
    new Libro("La vorágine", "José Eustasio Rivera", 1924),
    new Libro("Código limpio", "Robert C. Martin", 2008)
];

// Paso 2: Prestar el primero y mostrar todos
biblioteca[0].Prestar();
foreach (Libro libro in biblioteca)
{
Console.WriteLine(libro);
}

// LINQ: Mostrar los disponibles y el más antiguo
Console.WriteLine("\n--- Libros disponibles (LINQ) ---");
foreach (var libro in biblioteca.Where(l => l.Disponible))
{
Console.WriteLine(libro);
}

var masAntiguo = biblioteca.MinBy(l => l.Anio);
Console.WriteLine($"\n--- Libro más antiguo ---\n{masAntiguo}");

// Paso 3: Dos nombres, un solo objeto
Console.WriteLine("\n--- Paso 3: Referencia al mismo objeto ---");
Libro otro = biblioteca[1];
otro.Prestar();
Console.WriteLine(biblioteca[1]); // Aparece prestado



// PARTE 2 · ENCAPSULAMIENTO Y RECORDS

Console.WriteLine("\n\n=== PARTE 2: APRENDIZ Y VALIDACIONES ===");

// Paso 5: try/catch
try
{
var ana = new Aprendiz("Ana", 17, "1034567");
Console.WriteLine($"Registrada correctamente: {ana}");

var error = new Aprendiz("", 8, "abc");
}
catch (ArgumentException ex)
{
Console.WriteLine($"No se pudo registrar: {ex.Message}");
}

// Paso 6: Record Factura
Console.WriteLine("\n=== PASO 6: RECORD FACTURA ===");
var f1 = new Factura("F-001", "Ana", 150000m);
var f2 = new Factura("F-001", "Ana", 150000m);

Console.WriteLine(f1);                        // Se imprime solo
Console.WriteLine($"¿f1 == f2?: {f1 == f2}"); // True: mismos datos

var corregida = f1 with { Total = 180000m };
Console.WriteLine($"Factura corregida: {corregida}");


// DEFINICIÓN DE CLASES Y RECORDS


public record Factura(string Numero, string Cliente, decimal Total);

public class Libro
{
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public int Anio { get; private set; }
    public bool Disponible { get; private set; } = true;

    public Libro(string titulo, string autor, int anio)
    {
        Titulo = titulo;
        Autor = autor;
        Anio = anio;
    }

    public bool Prestar()
    {
        if (!Disponible) return false;
        Disponible = false;
        return true;
    }

    public void Devolver() => Disponible = true;

    public override string ToString() =>
        $"{Titulo} · {Autor} ({Anio}) · {(Disponible ? "Disponible" : "Prestado")}";
}

public class Aprendiz
{
    private string _nombre = "";
    private int _edad;
    private string _documento = "";

    public string Nombre
    {
        get => _nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío.");
            _nombre = value.Trim();
        }
    }

    public int Edad
    {
        get => _edad;
        set
        {
            if (value < 14 || value > 100)
                throw new ArgumentException("La edad debe estar entre 14 y 100 años.");
            _edad = value;
        }
    }

    public string Documento
    {
        get => _documento;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El documento no puede estar vacío.");

            string limpio = value.Trim();
            if (limpio.Length < 6 || limpio.Length > 10 || !limpio.All(char.IsDigit))
                throw new ArgumentException("El documento debe tener entre 6 y 10 dígitos numéricos.");

            _documento = limpio;
        }
    }

    public Aprendiz(string nombre, int edad, string documento)
    {
        Nombre = nombre;
        Edad = edad;
        Documento = documento;
    }

    public override string ToString() =>
        $"{Nombre} ({Edad} años) - Doc: {Documento}";
}