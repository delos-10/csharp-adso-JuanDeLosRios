using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // EJERCICIO 1: SEGUNDOS A RELOJ

            Console.WriteLine("=== SEGUNDOS A RELOJ ===");
            Console.Write("Ingrese los segundos: ");

            if (int.TryParse(Console.ReadLine(), out int totalSegundos))
            {
                if (totalSegundos >= 0)
                {
                    int horas = totalSegundos / 3600;
                    int minutos = (totalSegundos % 3600) / 60;
                    int segundos = totalSegundos % 60;

                    Console.WriteLine(horas + " h " + minutos + " min " + segundos + " s");
                }
                else
                {
                    Console.WriteLine("Ingrese segundos positivos.");
                }
            }
            else
            {
                Console.WriteLine("Dato no valido.");
            }

            // EJERCICIO 2: TEMPERATURA

            Console.WriteLine("\n=== TEMPERATURA ===");
            Console.Write("Ingrese grados Celsius: ");

            if (double.TryParse(Console.ReadLine(), out double celsius))
            {
                double fahrenheit = celsius * 9 / 5 + 32;
                Console.WriteLine("Grados Fahrenheit: " + fahrenheit);
            }
            else
            {
                Console.WriteLine("Dato no valido.");
            }

            // EJERCICIO 3: PROMEDIO DE NOTAS

            Console.WriteLine("\n=== PROMEDIO DE NOTAS ===");

            Console.Write("Ingrese la primera nota: ");
            bool ok1 = double.TryParse(Console.ReadLine(), out double nota1);

            Console.Write("Ingrese la segunda nota: ");
            bool ok2 = double.TryParse(Console.ReadLine(), out double nota2);

            Console.Write("Ingrese la tercera nota: ");
            bool ok3 = double.TryParse(Console.ReadLine(), out double nota3);

            if (ok1 && ok2 && ok3)
            {
                if (nota1 >= 0 && nota1 <= 5 &&
                    nota2 >= 0 && nota2 <= 5 &&
                    nota3 >= 0 && nota3 <= 5)
                {
                    double promedio = (nota1 + nota2 + nota3) / 3;
                    Console.WriteLine("Promedio: " + promedio.ToString("N1"));
                }
                else
                {
                    Console.WriteLine("Las notas deben estar entre 0 y 5.");
                }
            }
            else
            {
                Console.WriteLine("Debes ingresar notas numericas validas.");
            }

            Console.WriteLine("\nFin de los ejercicios.");
        }

    }
}
