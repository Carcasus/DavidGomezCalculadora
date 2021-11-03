using System;
using System.Collections.Generic;
using System.Text;

namespace DavidGomezCalculadora
{
    class Calculo
    {
        internal static double HacerOperacion(double numerador1, double numerador2, string operando)
        {
            double resultado = 0;
            // Use a switch statement to do the math.
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
                    // Ask the user to enter a non-zero divisor.
                    if (numerador2 != 0)
                    {
                        resultado = numerador1 / numerador2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return resultado;
        }
    }
}
