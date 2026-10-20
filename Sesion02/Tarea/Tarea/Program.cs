using System;

namespace Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random aleatorio = new Random();
            int secreto = aleatorio.Next(1, 101);
            int numero;
            bool acerto = false;

            for (int i = 1; i <= 7; i++)
            {
                Console.Write("Adivina el número (1-100): ");
                numero = int.Parse(Console.ReadLine() ?? "0");

                if (numero == secreto)
                {
                    Console.WriteLine("¡Correcto!");
                    Console.WriteLine($"Adivinaste en {i} intentos.");
                    acerto = true;
                    break;
                }
                else if (numero < secreto)
                {
                    Console.WriteLine("El número secreto es mayor.");
                }
                else
                {
                    Console.WriteLine("El número secreto es menor.");
                }
            }

            if (acerto == false)
            {
                Console.WriteLine($"No acertaste. El número era {secreto}.");
            }
        }
    }
}
