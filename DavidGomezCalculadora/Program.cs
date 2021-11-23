using System;

namespace DavidGomezCalculadora
{
    class Program
    {
        static int Main(String[] args) //pasarlo por los args para hacer el programa por linea de comandos
        {
            double resultado = 0;
            int codigoFinal = 0;

            double numerador1 = double.Parse(args[1]);
            double numerador2 = double.Parse(args[2]);
            try
            {
                resultado = Calculo.HacerOperacion(numerador1, numerador2, args[0]);
                if (double.IsNaN(resultado))
                {
                    Console.WriteLine("Esta operacion generara un error.\n");
                }
                /*A de devolver por consola el resultado de la operación.*/
                else Console.WriteLine("Tu resultado es: " + numerador1 + " + " + numerador2 + " = " + resultado);
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