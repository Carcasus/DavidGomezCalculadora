using System;

namespace DavidGomezCalculadora
{
    /*Realizar un programa en un solo proceso, en el que realice una operación de cálculo.

    El proceso ha de admitir parámetros por línea de comandos.
    Se ha de indicar la operación y dos valores numéricos a tratar.
    A de poder soportar al menos las operaciones suma, resta, multiplicación y división.
    A de devolver por consola el resultado de la operación.
    A de devolver 0 si el proceso termina correctamente y otro valor si se ha producido un error.*/

    class Program
    {
        static void Main(string[] args)
        {
            Boolean finalizar = false;

            while (finalizar == false)
            {
                Console.WriteLine("Calculadora por linea de comandos\r");
                Console.WriteLine("------------------------\n");

                Console.WriteLine("Escriba, pulsando enter con cada valor, el comando y los dos numeros a usar en la calculadora ");
                Console.WriteLine("escriba help en caso de que no sepa como escribir los operandos");
                /*El proceso ha de admitir parámetros por línea de comandos.*/
                /*Se ha de indicar la operación y dos valores numéricos a tratar.*/
                String num1 = "";
                String num2 = "";
                double resultado = 0;
                
                String operando = Console.ReadLine();

                //Dar al usuario la posibilidad de recibir ayuda si no sabe claramente como escribir el codigo
                if (operando == "help")
                {
                    ShowHelp();
                }
                else if (operando != "add" || operando != "sub" || operando != "plus" || operando != "div")
                {
                    ShowError();
                }
                else
                {
                    num1 = Console.ReadLine();
                    num2 = Console.ReadLine();

                    //Variable para comprobar sin cierre del programa, que las variables numericas son correctas
                    double numerador1 = 0;
                    double numerador2 = 0;

                    //Linea comprobante del correcto uso de los comandos
                    if (operando == null || !double.TryParse(num1, out numerador1) || !double.TryParse(num2, out numerador2))
                    {
                        ShowError();
                        return;
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
                            else Console.WriteLine("Tu resultado es: " + resultado);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ha ocurrido un error intentando hacer la operacion.\n - Details: " + e.Message);
                        }

                        Console.WriteLine("------------------------\n");


                        Console.WriteLine("0\n");
                        Console.WriteLine("Pulsa intro para finalizar el programa");
                        Console.Read(); //Con el read podremos detener momentaneamente la consola
                        finalizar = true;
                    }
                }
            }

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