using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola Universo");
            Console.WriteLine("como te llamas?");
            string entrada = Console.ReadLine() ?? "";
            string nombre = string.IsNullOrWhiteSpace(entrada) ? "Invitado" : entrada;

            Console.WriteLine("cual es tu edad?");
            entrada = Console.ReadLine() ?? "";
            int edad = string .IsNullOrWhiteSpace(entrada) ? 0 : Convert.ToInt32(entrada);

            Console.Write("De que ciudad eres?: ");
            entrada = Console.ReadLine();
            string ciudad = string.IsNullOrWhiteSpace(entrada) ? "sin ciudad" : entrada;

            Console.WriteLine($"su nombre es : {nombre}, usted tiene {edad} años y su ciudad es {ciudad}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Este renglon lo estas viendo amarillo.");
            Console.ResetColor();

            Console.WriteLine("== Ejemplos de operaciones ==");

            Console.WriteLine(7 / 2);
            Console.WriteLine(7 / 2.0);
            Console.WriteLine(7 % 2);
            Console.WriteLine((10 + 3) * 2);

        }
    }
}
