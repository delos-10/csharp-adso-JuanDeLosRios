
using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== GENERADOR DE USUARIOS ===");

        Console.Write("Ingrese el nombre completo: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Ingrese el documento: ");
        string documento = Console.ReadLine() ?? "";

        string usuario = GenerarUsuario(nombre, documento);

        Console.WriteLine("Usuario generado: " + usuario);

        Console.WriteLine();
        Console.WriteLine("=== ANALIZADOR DE FRASES ===");

        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine() ?? "";

        AnalizarFrase(frase);
    }

    static string GenerarUsuario(string nombreCompleto, string documento)
    {
        nombreCompleto = nombreCompleto.Trim();

        nombreCompleto = nombreCompleto
            .Replace("á", "a").Replace("é", "e")
            .Replace("í", "i").Replace("ó", "o")
            .Replace("ú", "u").Replace("ñ", "n")
            .Replace("Á", "A").Replace("É", "E")
            .Replace("Í", "I").Replace("Ó", "O")
            .Replace("Ú", "U").Replace("Ñ", "N");

        string[] nombres = nombreCompleto.Split(
            ' ', StringSplitOptions.RemoveEmptyEntries);

        if (nombres.Length < 2)
        {
            return "Ingrese nombre y apellido";
        }

        if (documento.Length < 2)
        {
            return "Documento no valido";
        }

        int posicionApellido;

        if (nombres.Length >= 4)
        {
            posicionApellido = 2;
        }
        else
        {
            posicionApellido = 1;
        }

        string inicial = nombres[0].Substring(0, 1);
        string apellido = nombres[posicionApellido];

        string ultimosDigitos = documento.Substring(documento.Length - 2);

        string usuario = (inicial + apellido + ultimosDigitos).ToLower();

        return usuario;
    }

    static void AnalizarFrase(string frase)
    {
        string[] palabras = frase.Split(
            ' ', StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Cantidad de palabras: " + palabras.Length);

        StringBuilder fraseInvertida = new StringBuilder();

        for (int i = palabras.Length - 1; i >= 0; i--)
        {
            fraseInvertida.Append(palabras[i]);

            if (i > 0)
            {
                fraseInvertida.Append(" ");
            }
        }

        Console.WriteLine("Frase en orden inverso: " + fraseInvertida.ToString());
    }
}
