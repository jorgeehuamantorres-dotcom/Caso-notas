using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_notas
{
    internal class Program
    {
        //funcion sin retorno
        static public void Titulo()
        {
            Console.WriteLine("************************");
            Console.WriteLine("\t\tUPN");
            Console.WriteLine("************************");
        }
        //funcion con retorno
        static public double Validar_nota(String mensaje)
        {
            double nota;
            while (true)
            {
                Console.Write(mensaje);
                String entrada = Console.ReadLine();
                if (double.TryParse(entrada, out nota) && nota >= 0 && nota <= 20)
                    return nota;
                Console.WriteLine("Error ingrese un valor entre (0,20)");
            }
        }
        static public double Calcula_ef(double Proyecto_F, double Lab)
        {
            double prom_EF;
            prom_EF = Proyecto_F * 0.6 + Lab * 0.4;
            return prom_EF;
        }
        static public double Bono_Cisco(double nota_EF, String Tiene_Cisco)
         {
            if (Tiene_Cisco == "s")
            {
                nota_EF += 1;
                if (nota_EF > 20)
                    nota_EF = 20;
            }
            return nota_EF;
         }
        static public double promedio_curso(double t1, double t2, double t3, double ep, double ef)
        {
            double promedio;
            promedio = (t1 * 0.1 + t2 * 0.1 + t3 * 0.1+ ep*0.2+ef*0.5);
            return promedio;
        }
        static public String Condicion(double promedio)
        {
            string estado;
            if (promedio >= 12)
                estado = "APROBADO";
            else
                estado = "DESAPROBADO";
            return estado;

        }
        static void Main(string[] args)
        {
            string curso_cisco;
            Titulo();
            Console.Write("Ingresar el nombre del estudiante: ");
            string nombre=Console.ReadLine();
            Console.WriteLine("****************INGRESO DE NOTAS*******************");
            double t1=Validar_nota("Ingresar nota T1: ");
            double t2 = Validar_nota("Ingresar nota T2: ");
            double t3 = Validar_nota("Ingresar nota T3: ");
            double ep = Validar_nota("Ingresar nota del examne parcial: ");
            Console.WriteLine("ingresar notas para el Examen final");
            double Proy_final= Validar_nota("Ingresar nota del Proyecto final: ");
            double Lab = Validar_nota("Ingresar nota del Laboratorio: ");
            //validando
            while (true)
            {
                Console.Write("realizo el curso de cisco [s/n]: ");
                curso_cisco = Console.ReadLine().ToLower();
                if (curso_cisco == "s" || curso_cisco == "n")
                    break;
                Console.WriteLine("Error ingresar [s/n]: ");
            }
            double notaEF = Calcula_ef(Proy_final, Lab);
            double notaEF_cisco=Bono_Cisco(notaEF,curso_cisco);
            double promedio=promedio_curso(t1,t2,t3,ep,notaEF_cisco);
            string condicion_Est = Condicion(promedio);

            Console.WriteLine("====================================");
            Console.WriteLine("\tREPORTE FINAL:", nombre);
            Console.WriteLine("====================================");
            if (curso_cisco == "s")
                Console.WriteLine("FELICITACIONES POR LLEVAR EL CURSO DE CISCO");
            Console.WriteLine("Nota Examen Final: " + notaEF_cisco);
            Console.WriteLine("El promedio del curso: " + promedio);
            Console.WriteLine("Condicion: " + condicion_Est);
            Console.ReadKey();
        }
    }
}
