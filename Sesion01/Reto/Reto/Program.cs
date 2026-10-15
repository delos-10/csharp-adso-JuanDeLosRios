using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("=== CALCULADORA DE PROPINAS ===");

            Console.Write("Total de la cuenta: ");
            bool okTotal = decimal.TryParse(Console.ReadLine(), out decimal total);

            Console.WriteLine("\nSeleccione el porcentaje de propina:");
            Console.WriteLine("1. 10%");
            Console.WriteLine("2. 15%");
            Console.WriteLine("3. 20%");
            Console.WriteLine("4. Otro porcentaje");
            Console.Write("Opcion: ");

            bool okOpcion = int.TryParse(Console.ReadLine(), out int opcion);

            decimal porcentaje = 0;
            bool okPct = false;

            if (okOpcion)
            {
                if (opcion == 1)
                {
                    porcentaje = 10;
                    okPct = true;
                }
                else if (opcion == 2)
                {
                    porcentaje = 15;
                    okPct = true;
                }
                else if (opcion == 3)
                {
                    porcentaje = 20;
                    okPct = true;
                }
                else if (opcion == 4)
                {
                    Console.Write("Porcentaje de propina: ");
                    okPct = decimal.TryParse(Console.ReadLine(), out porcentaje);
                }
            }

            Console.Write("Numero de personas: ");
            bool okPersonas = int.TryParse(Console.ReadLine(), out int personas);

            if (okTotal && okPct && okPersonas)
            {
                if (personas <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El numero de personas debe ser mayor que cero.");
                    Console.ResetColor();
                }
                else if (total < 0 || porcentaje < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El total y el porcentaje no pueden ser negativos.");
                    Console.ResetColor();
                }
                else
                {
                    decimal propina = total * porcentaje / 100m;
                    decimal totalPagar = total + propina;
                    decimal porPersona = totalPagar / personas;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n=== RESULTADO ===");
                    Console.WriteLine($"Propina: {propina:C0}");
                    Console.WriteLine($"Total: {totalPagar:C0}");
                    Console.WriteLine($"Cada persona paga: {porPersona:C0}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: ingrese datos validos.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione una tecla para salir.");
            Console.ReadKey();
        }
    }
}
