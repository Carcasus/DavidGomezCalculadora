using System;

namespace DavidGomezCalculadora
{
    class Program
    {
        static int Main(string[] args) //pasarlo por los args para hacer el programa por linea de comandos
        {
            /*El proceso ha de admitir parámetros por línea de comandos.*/
            /*Se ha de indicar la operación y dos valores numéricos a tratar.*/
            Console.WriteLine("Calculadora por linea de comandos\r");
            Console.WriteLine("------------------------\n");
            String operando = args[0];
            String num1 = args[1];
            String num2 = args[2];
            int codigoFinal = 0;

            codigoFinal = Calculadora(operando, num1, num2);

            return codigoFinal;
        }

        static int Calculadora(string operando, String num1, String num2)
        {
            double resultado = 0;
            int codigoFinal = 0;

            if (operando == "add" || operando == "sub" || operando == "plus" || operando == "div")
            {

                //Variable para comprobar sin cierre del programa, que las variables numericas son correctas
                double numerador1 = 0;
                double numerador2 = 0;
                

                //Linea comprobante del correcto uso de los comandos
                if (!double.TryParse(num1, out numerador1) || !double.TryParse(num2, out numerador2))
                {
                    ShowError();
                    codigoFinal = 1;
                }
                else
                {
                    /*A de devolver 0 si el proceso termina correctamente y otro valor si se ha producido un error.*/
                    try
                    {
                        resultado = Calculo.HacerOperacion(numerador1, numerador2, operando);
                        if (double.IsNaN(resultado))
                        {
                            Console.WriteLine("Esta operacion generara un error.\n");
                        }
                        /*A de devolver por consola el resultado de la operación.*/
                        else Console.WriteLine("Tu resultado es: "+ num1 +" + "+ num2+" = " + resultado);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ha ocurrido un error intentando hacer la operacion.\n - Details: " + e.Message);
                        codigoFinal = 2;
                    }
                }
            }
            else
            {
                ShowError();
                codigoFinal = 1;
            }
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