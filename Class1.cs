using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_notas
{
    internal class Class1
    
    {
        // Variable global (estática para ser accedida desde métodos estáticos)
        static double saldo = 1000.00;

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                MostrarMenu();

                // Validación básica para evitar errores si el usuario ingresa texto
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ConsultarSaldo();
                            break;
                        case 2:
                            DepositarDinero();
                            break;
                        case 3:
                            RetirarDinero();
                            break;
                        case 4:
                            MostrarNumeros();
                            break;
                        case 5:
                            Console.WriteLine("\n¡Gracias por utilizar nuestros servicios! Saliendo del sistema...");
                            break;
                        default:
                            Console.WriteLine("\n[Error] Opción no válida. Por favor, elija entre 1 y 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n[Error] Entrada no válida. Ingrese un número entero.");
                    opcion = 0; // Mantiene el ciclo activo
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 5);
        }

        // Método para mostrar el menú principal
        static void MostrarMenu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       SIMULADOR DE CAJERO AUTOMÁTICO   ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar");
            Console.WriteLine("3. Retirar");
            Console.WriteLine("4. Mostrar números");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }

        // 1. Consultar saldo
        static void ConsultarSaldo()
        {
            Console.WriteLine($"\n[Consulta] Su saldo actual es: S/ {saldo:F2}");
        }

        // 2. Depositar
        static void DepositarDinero()
        {
            Console.Write("\nIngrese el monto a depositar (S/): ");
            if (double.TryParse(Console.ReadLine(), out double monto) && monto > 0)
            {
                saldo += monto;
                Console.WriteLine($"\n[Éxito] Depósito realizado correctamente.");
                ConsultarSaldo();
            }
            else
            {
                Console.WriteLine("\n[Error] El monto debe ser mayor a cero.");
            }
        }

        // 3. Retirar
        static void RetirarDinero()
        {
            Console.Write("\nIngrese el monto a retirar (S/): ");
            if (double.TryParse(Console.ReadLine(), out double monto) && monto > 0)
            {
                if (monto <= saldo)
                {
                    saldo -= monto;
                    Console.WriteLine($"\n[Éxito] Retiro procesado con éxito.");
                    ConsultarSaldo();
                }
                else
                {
                    Console.WriteLine("\n[Error] Fondos insuficientes. No puede retirar más de su saldo actual.");
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Ingrese un monto válido mayor a cero.");
            }
        }

        // 4. Mostrar números (Bucle for)
        static void MostrarNumeros()
        {
            Console.Write("\nIngrese el límite para el conteo incremental: ");
            if (int.TryParse(Console.ReadLine(), out int limite) && limite > 0)
            {
                Console.WriteLine($"\n--- Conteo del 1 al {limite} ---");
                for (int i = 1; i <= limite; i++)
                {
                    Console.Write(i + (i < limite ? ", " : ""));
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\n[Error] Debe ingresar un número entero positivo.");
            }
        }
    }
}
