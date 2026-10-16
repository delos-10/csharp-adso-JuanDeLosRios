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

            int saldo = 500000;
            int transacciones = 0;
            bool acceso = false;

            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Ingrese el PIN: ");
                string pin = Console.ReadLine();

                if (pin == "1234")
                {
                    acceso = true;
                    Console.WriteLine("Bienvenido al cajero");
                    Console.WriteLine($"Su saldo inicial es de ${saldo}");
                    break;
                }
                else
                {
                    Console.WriteLine("PIN incorrecto");
                }
            }
            if (acceso == false)
            {
                Console.WriteLine("Tarjeta bloqueada");
                return;
            }

            int opc = 0;

            do
            {
                Console.WriteLine("Digite la opcion deseada: \n1. Consultar saldo\n2. Depositar\n3. Retirar\n4. Salir.\nElige la opcion: ");

                string entrada = Console.ReadLine();

                if (!int.TryParse(entrada, out opc))
                {
                    Console.WriteLine("Ingrese una opcion valida");
                    continue;
                }

                switch (opc)
                {
                    case 1:
                        Console.WriteLine($"Su saldo es: ${saldo}");
                        break;

                    case 2:
                        Console.Write("Ingrese el valor a depositar: ");

                        if (int.TryParse(Console.ReadLine(), out int deposito))
                        {
                            if (deposito > 0)
                            {
                                saldo = saldo + deposito;
                                transacciones++;
                                Console.WriteLine("Deposito realizado correctamente");
                                Console.WriteLine($"Nuevo saldo: ${saldo}");
                            }
                            else
                            {
                                Console.WriteLine("El valor debe ser mayor que cero");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un numero valido");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el valor a retirar: ");

                        if (int.TryParse(Console.ReadLine(), out int retiro))
                        {
                            if (retiro > 0 && retiro % 10000 == 0)
                            {
                                if (retiro <= saldo)
                                {
                                    saldo = saldo - retiro;
                                    transacciones++;
                                    Console.WriteLine("Retiro realizado correctamente");
                                    Console.WriteLine($"Nuevo saldo: ${saldo}");
                                }
                                else
                                {
                                    Console.WriteLine("Saldo insuficiente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("El retiro debe ser positivo y multiplo de $10.000");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un numero valido");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Gracias por utilizar el cajero");
                        Console.WriteLine($"Transacciones realizadas: {transacciones}");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }

            } while (opc != 4);

        }
    }
}

