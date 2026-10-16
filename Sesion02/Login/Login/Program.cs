using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ingrese su Usuario:");
            string user = Console.ReadLine().ToLower().Trim();
            Console.WriteLine("ingrese su Contraseña:");
            string pass = Console.ReadLine().ToLower().Trim();
            if (user == "admin" && pass == "12345")
            {
                Console.WriteLine("bienvenido al Sistema");
                Console.WriteLine("Calculadora con Swicth");
                Console.WriteLine("digite el valor para A");
                string entrada = Console.ReadLine().Trim();
                int a = Convert.ToInt32(entrada);
                Console.WriteLine("digite el valor para B");
                float b = Convert.ToInt32(Console.ReadLine());

                //Console.WriteLine("Digite la opción deseada");
                //Console.WriteLine("1. Sumar");
                //Console.WriteLine("2. Restar");
                //Console.WriteLine("3. Multiplicar");
                //Console.WriteLine("4. Dividir");

                Console.WriteLine("Digite la opcion deseada:\n1.sumar\n2.restar\n3.multiplicar\n4.dividir");


                int opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.WriteLine($"La suma de {a} + {b} es {a + b}");
                        break;
                    case 2:
                        Console.WriteLine($"La resta de {a} - {b} es {a - b}");
                        break;
                    case 3:
                        Console.WriteLine($"La multiplicacion de {a} * {b} es {a * b}");
                        break;
                    case 4:
                        if (b == 0)
                            Console.WriteLine($"La división no se puede dividir entre cero");
                        else
                            Console.WriteLine($"La división de {a} / {b} es {a / b}");
                        break;
                    case 5:
                        double nota = Convert.ToDouble(Console.ReadLine());
                        if (nota < 0 || nota > 5)
                            Console.WriteLine("la nota debe ser entre 0.0 y 5.0");
                        else
                        {
                            if (nota <= 3.0)
                                Console.WriteLine("nota: deficiente");
                            else if (nota < 4)
                                Console.WriteLine("nota: aceptable");
                            else if (nota < 4.6)
                                Console.WriteLine("nota: sobresaliente");
                            else
                                Console.WriteLine("nota: excelente");
                        }
                        break;
                    default:
                        Console.WriteLine("Eleccion incorrecta");
                        break;

                }


            }
            else
                Console.WriteLine("Error en el usuario o contraseña");

        }
    }
}
