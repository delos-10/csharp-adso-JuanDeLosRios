
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string clave = "";
        int puntos = 0;

        do
        {
            Console.Write("Ingrese una contraseña: ");
            clave = Console.ReadLine() ?? "";

            puntos = Evaluar(clave);

            if (puntos == 6)
            {
                Console.WriteLine("Nivel: Fuerte (" + puntos + "/6)");
            }
            else if (puntos >= 4)
            {
                Console.WriteLine("Nivel: Media (" + puntos + "/6)");
            }
            else
            {
                Console.WriteLine("Nivel: Débil (" + puntos + "/6)");
            }

            Console.WriteLine();

        } while (puntos != 6);

        Console.WriteLine("Contraseña aceptada.");
    }

    static int Evaluar(string clave)
    {
        bool mayuscula = false;
        bool minuscula = false;
        bool numero = false;
        bool especial = false;
        bool espacio = false;

        foreach (char c in clave)
        {
            if (char.IsUpper(c))
            {
                mayuscula = true;
            }
            else if (char.IsLower(c))
            {
                minuscula = true;
            }
            else if (char.IsDigit(c))
            {
                numero = true;
            }
            else if (char.IsWhiteSpace(c))
            {
                espacio = true;
            }
            else if (char.IsPunctuation(c) || char.IsSymbol(c))
            {
                especial = true;
            }
        }

        string[] reglas =
        {
            "Minimo 8 caracteres",
            "Una mayuscula",
            "Una minuscula",
            "Un numero",
            "Un caracter especial",
            "Sin espacios"
        };

        bool[] cumple =
        {
            clave.Length >= 8,
            mayuscula,
            minuscula,
            numero,
            especial,
            !espacio
        };

        int puntos = 0;

        for (int i = 0; i < cumple.Length; i++)
        {
            if (cumple[i])
            {
                Console.WriteLine("✅ " + reglas[i]);
                puntos++;
            }
            else
            {
                Console.WriteLine("❌ " + reglas[i]);
            }
        }

        return puntos;
    }
}
