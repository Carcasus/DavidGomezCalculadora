using System;
using System.Diagnostics;

namespace ClasePadre
{
    class Program
    {
        /*Utilizando el programa de la practica anterior como proceso hijo, se ha de realizar un proceso padre que realice los siguientes funciones:
        Pida por consola una operación y dos valores.
        Llame al proceso hijo, pasándole como parámetros la operación y dos valores numéricos.
        Recoja el resultado de la operación por consola.
        Recoja el resultado de finalización del proceso hijo.
        Muestre los resultados por consola.*/

        static int Main(string[] args) /*Pida por consola una operación y dos valores.*/
        {
            Console.WriteLine("Calculadora por linea de comandos\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Escribe los argumentos");
            String operando = Console.ReadLine();
            String num1 = Console.ReadLine();
            String num2 = Console.ReadLine();
            int codigoFinal = 0;

            String argumentos = operando + " " + num1 + " " + num2;

            //Variable para comprobar sin cierre del programa, que las variables numericas son correctas
            double numerador1 = 0;
            double numerador2 = 0;
            
            if (!double.TryParse(num1, out numerador1) || !double.TryParse(num2, out numerador2))
            {
                ShowError();
                codigoFinal = 1;
            }
            else if (operando == "add" || operando == "sub" || operando == "plus" || operando == "div")
            {
                //Creamos el proceso con los datos necesarios
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = @".\DavidGomezCalculadora.exe",
                    Arguments = argumentos,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                /*Llame al proceso hijo, pasándole como parámetros la operación y dos valores numéricos (a la otra clase).*/
                using Process procesoHijo = Process.Start(startInfo);

                /*Recoja el resultado de la operación por consola.*/
                var output = procesoHijo.StandardOutput;
                var error = procesoHijo.StandardError;

                /*Recoja el resultado de finalización del proceso hijo.*/
                procesoHijo.WaitForExit();

                
                codigoFinal = procesoHijo.ExitCode;
                output.ReadToEnd();

            }
            else
            {
                ShowError();
                codigoFinal = 2;
            }
            /*Muestre los resultados por consola.*/
            return codigoFinal;
        }

        private static void ShowError()
        {
            Console.WriteLine("Error: linea de comando mal formada.");
            ShowHelp();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("\nUSO:");
            Console.WriteLine("Debes de escribir cada elemento separado por un enter");
            Console.WriteLine("[comando]\n[valor1]\n[valor2]");
            Console.WriteLine("Los comandos disponibles en la calculadora son:\n");
            Console.WriteLine("\tadd");
            Console.WriteLine("\tsub");
            Console.WriteLine("\tplus");
            Console.WriteLine("\tdiv\n");
        }

    }
}
