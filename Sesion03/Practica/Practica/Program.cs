using System.Text;

//Console.WriteLine("Hello, World!");

//MostrarTitulo("Mis métodos");
//Console.WriteLine(Sumar(5, 3));
//Console.WriteLine(EsPar(7));

////este es un procedimiento:no devuelve nada.
//static void MostrarTitulo(string texto)
//{
//    Console.WriteLine($"=== {texto.ToUpper()} ===");
//}

////Esta es una funcion: porque devuelve algo.
//static int Sumar(int a, int b)
//{
//    return a + b;
//}

//static bool EsPar(int numero) => numero % 2 == 0;


////SObrecargas y Parametros opcionales
//static double Area(double lado) => lado * lado;
//static double Area1(double ancho, double alto) => ancho * alto;

//Area(4);
//Area1(4, 3);



//static void Saludar(string nombre, string saludo = "Hola")
//{
//    Console.WriteLine($"{saludo}, {nombre}");
//}
//Saludar("Juan", "Bienbenido");
//Saludar("Juan");
//Saludar("");

////Metodos comodin
//static int LeerEntero(string mensaje)
//{
//    Console.Write(mensaje);
//    int valor;
//    while (!int.TryParse(Console.ReadLine(), out valor))
//    {
//        Console.Write("Valor no válido. Intenta de nuevo\nDigite un numero entero: ");

//    }
//    return valor;
//}

//Console.WriteLine(LeerEntero("digite un numero entero: "));

//static decimal LeerDecimal(string mensaje)
//{
//    Console.Write(mensaje);
//    decimal valor;
//    while (!decimal.TryParse(Console.ReadLine(), out valor))
//    {
//        Console.Write("Valor no válido. Intenta de nuevo\nDigite un numero decimal:  ");
//    }
//    return valor;
//}
//Console.WriteLine(LeerDecimal("digite un número decimal: "));


////Arreglos y cadenas

//decimal[] notas = new decimal[5]; //declara el arreglo
//for (int i = 0; i < notas.Length; i++)
//{
//    notas[i] = LeerDecimal($"Nota {i + 1}: ");

//}
//Console.WriteLine(string.Join(" | ", notas)); //imprime o muestra el arreglo



////=== contar vocales en una frase
//static int ContarVocales(string texto)
//{
//    int totalvocales = 0;
//    foreach (char c in texto.ToLower())
//    {
//        if ("aeiouáéíóú".Contains(c)) 
//            totalvocales++;
//    }
//    return totalvocales;
//}

//Console.WriteLine(ContarVocales("hola profe querido"));


//Console.WriteLine(char.IsDigit('7'));      // true  → es un dígito (0-9)
//Console.WriteLine(char.IsDigit('a'));      // false

//Console.WriteLine(char.IsUpper('A'));      // true  → es letra mayúscula
//Console.WriteLine(char.IsUpper('a'));      // false

//Console.WriteLine(char.IsLower('a'));      // true  → es letra minúscula
//Console.WriteLine(char.IsLower('A'));      // false

//Console.WriteLine(char.IsWhiteSpace(' '));  // true  → espacio, tab (\t), salto de línea (\n)...
//Console.WriteLine(char.IsWhiteSpace('x'));  // false


// contar tipos de caracteres en un texto
string texto = "@ Hola Mundo 2026_04";

int digitos = 0, mayusculas = 0, minusculas = 0, espacios = 0, especiales = 0;

Console.WriteLine(texto);

foreach (char c in texto)
{
    if (char.IsDigit(c)) digitos++;
    else if (char.IsUpper(c))
        mayusculas++;
    else if (char.IsLower(c))
        minusculas++;
    else if (char.IsWhiteSpace(c))
        espacios++;
    else if (char.IsSymbol(c))
        especiales++;
}

Console.WriteLine($"Dígitos: {digitos}");        // 4
Console.WriteLine($"Mayúsculas: {mayusculas}");  // 2
Console.WriteLine($"Minúsculas: {minusculas}");  // 7
Console.WriteLine($"Espacios en blanco: {espacios}");      // 2
Console.WriteLine($"Caracteres Especiales: {especiales}");

// primera fila del archivo


static string Invertir(string texto)
{
    var sb = new StringBuilder();
    for (int i = texto.Length - 1; i >= 0; i--) sb.Append(texto[i]);
    return sb.ToString();
}

Console.WriteLine(Invertir("juan"));