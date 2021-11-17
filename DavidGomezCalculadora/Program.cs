using System;

namespace DavidGomezCalculadora
{
    class Program
    {
        static int Main(String operando, String num1, String num2) //pasarlo por los args para hacer el programa por linea de comandos
        {
            double resultado = 0;
            int codigoFinal = 0;

            //Variable para comprobar sin cierre del programa, que las variables numericas son correctas
            double numerador1 = 0;
            double numerador2 = 0;
            try
            {
                resultado = Calculo.HacerOperacion(numerador1, numerador2, operando);
                if (double.IsNaN(resultado))
                {
                    Console.WriteLine("Esta operacion generara un error.\n");
                }
                /*A de devolver por consola el resultado de la operación.*/
                else Console.WriteLine("Tu resultado es: " + num1 + " + " + num2 + " = " + resultado);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha ocurrido un error intentando hacer la operacion.\n - Details: " + e.Message);
                codigoFinal = 2;
            }
            return codigoFinal;
        }
    }
}