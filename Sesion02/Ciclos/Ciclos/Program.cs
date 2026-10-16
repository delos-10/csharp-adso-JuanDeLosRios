using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciclos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ////Ciclos
            //for (int i = 0; i <= 10; i++)
            //    {
            //        Console.WriteLine($"valor: {i}");
            //    }

            //Ciclos do - while
            //int edad;
            //do
            //{
            //    Console.Write("Edad (1 a 120): ");
            //} while (!int.TryParse(Console.ReadLine(), out edad) || edad < 1 || edad > 120);

            //int suma = 0;
            //for (int i = 1; i < 6; i++)
            //{
            //    Console.Write($"Puntaje {i}: ");
            //    int.TryParse(Console.ReadLine(), out int puntaje);
            //    suma += puntaje;
            //}
            //double promedio = suma / 5.0;
            //Console.WriteLine($"Promedio: {promedio}");

            Console.Write(" ==== Tabla de multiplicar ==== ");
            double tabla;

            do
            {
                Console.Write("\ndigite un numero para generar su tabla de multiplicar: ");
            } while (!double.TryParse(Console.ReadLine(), out tabla));
            Console.WriteLine($"la tabla del {tabla} es: ");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{tabla} x {i} = {tabla * i}");
            }
            

        }
    }
}
