Dictionary<string, List<double>> notas = new(StringComparer.OrdinalIgnoreCase);

int opcion;
do
{
    Console.WriteLine("\n--- GESTOR DE NOTAS ---");
    Console.WriteLine("1. Registrar aprendiz");
    Console.WriteLine("2. Agregar nota");
    Console.WriteLine("3. Listar todos");
    Console.WriteLine("4. Ranking por promedio");
    Console.WriteLine("5. Mejor aprendiz y aprobados");
    Console.WriteLine("6. Eliminar aprendiz");
    Console.WriteLine("7. Salir");

    opcion = LeerEntero("Opción: ");

    switch (opcion)
    {
        case 1: RegistrarAprendiz(); 
            break;
        case 2: AgregarNota(); 
            break;
        case 3: ListarTodos(); 
            break;
        case 4: MostrarRanking(); 
            break;
        case 5: MejorYAprobados(); 
            break;
        case 6: EliminarAprendiz(); 
            break;
        case 7: Console.WriteLine("Saliendo..."); 
            break;
        default: Console.WriteLine("Opción no válida."); 
            break;
    }
} while (opcion != 7);

void RegistrarAprendiz()
{
    Console.Write("Nombre del aprendiz: ");
    string nombre = Console.ReadLine()?.Trim() ?? "";

    if ( nombre == "" )
    {
        Console.WriteLine("El nombre no puede estar vacío.");
        return;
    }

    if (notas.ContainsKey(nombre))
    {
        Console.WriteLine("Ese aprendiz ya está registrado.");
        return;
    }

    notas[nombre] = [];
    Console.WriteLine("Aprendiz registrado.");
}

void AgregarNota()
{
    Console.Write("Nombre del aprendiz: ");
    string nombre = Console.ReadLine()?.Trim() ?? "";

    if (!notas.TryGetValue(nombre, out List<double>? lista))
    {
        Console.WriteLine("No se encontró el aprendiz.");
        return;
    }

    double nota = LeerDouble("Nota (0 a 5): ");
    if (nota < 0 || nota > 5)
    {
        Console.WriteLine("La nota debe estar entre 0 y 5.");
        return;
    }

    lista.Add(nota);
    Console.WriteLine("Nota guardada.");
}

void ListarTodos()
{
    if (notas.Count == 0)
    {
        Console.WriteLine("No hay aprendices registrados.");
        return;
    }

    foreach (var (nombre, lista) in notas)
    {
        double promedio = lista.Count > 0 ? lista.Average() : 0;
        string juicio = promedio >= 3.0 ? "A" : "D";
        Console.WriteLine($"{nombre,-15} {lista.Count} notas · Promedio {promedio:N1} · Juicio {juicio}");
    }
}

void MostrarRanking()
{
    var conNotas = notas
        .Where(a => a.Value.Count > 0)
        .OrderByDescending(a => a.Value.Average())
        .ToList();

    if (conNotas.Count == 0)
    {
        Console.WriteLine("Aún no hay aprendices con notas.");
        return;
    }

    int pos = 1;
    foreach (var (nombre, lista) in conNotas)
    {
        double promedio = lista.Average();
        string juicio = promedio >= 3.0 ? "A" : "D";
        Console.WriteLine($"{pos}. {nombre,-15} {lista.Count} notas · Promedio {promedio:N1} · Juicio {juicio}");
        pos++;
    }
}

void MejorYAprobados()
{
    var conNotas = notas.Where(a => a.Value.Count > 0).ToList();

    if (conNotas.Count == 0)
    {
        Console.WriteLine("Aún no hay aprendices con notas.");
        return;
    }

    var mejor = conNotas.MaxBy(a => a.Value.Average());
    int aprobados = conNotas.Count(a => a.Value.Average() >= 3.0);

    Console.WriteLine($"Mejor aprendiz: {mejor.Key} (Promedio {mejor.Value.Average():N1})");
    Console.WriteLine($"Aprendices aprobados: {aprobados}");
}

void EliminarAprendiz()
{
    Console.Write("Nombre a eliminar: ");
    string nombre = Console.ReadLine()?.Trim() ?? "";

    if (notas.Remove(nombre))
        Console.WriteLine("Aprendiz eliminado.");
    else
        Console.WriteLine("No se encontró el aprendiz.");
}

int LeerEntero(string mensaje)
{
    int valor;
    Console.Write(mensaje);
    while (!int.TryParse(Console.ReadLine(), out valor))
        Console.Write("Ingrese un número válido: ");
    return valor;
}

double LeerDouble(string mensaje)
{
    double valor;
    Console.Write(mensaje);
    while (!double.TryParse(Console.ReadLine(), out valor))
        Console.Write("Ingrese un número válido: ");
    return valor;
}