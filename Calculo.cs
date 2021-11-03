using System;
using System.Collections.Generic;
using System.Text;

namespace DavidGomezCalculadora
{
    class Calculo
    {
        /*A de poder soportar al menos las operaciones suma, resta, multiplicación y división.*/
        internal static double HacerOperacion(double numerador1, double numerador2, string operando)
        {
            double resultado = 0;

            switch (operando)
            {
                case "add":
                    resultado = numerador1 + numerador2;
                    break;
                case "sub":
                    resultado = numerador1 - numerador2;
                    break;
                case "plus":
                    resultado = numerador1 * numerador2;
                    break;
                case "div":
                    // Pedimos al usuario que escriba un divisor que no sea cero
                    if (numerador2 == 0.0)
                        Console.WriteLine("No se dividir entre 0");
                    else
                        resultado = numerador1 / numerador2;
                    break;
                // Si no es ninguno de estos operandos, se devuelve vacio.
                default:
                    break;
            }
            return resultado;
        }
    }
}
