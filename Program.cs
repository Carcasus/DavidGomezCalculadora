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
            Console.WriteLine("Calculadora por linea de comandos\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Escriba, pulsando enter con cada valor, el comando y los dos numeros a usar en la calculadora ");
            Console.WriteLine("\tadd");
            Console.WriteLine("\tsub");
            Console.WriteLine("\tplus");
            Console.WriteLine("\tdiv");
            Console.WriteLine("escriba help en caso de que no sepa como escribir los operandos");

            String num1 = "";
            String num2 = "";
            double resultado = 0;

            /*Se ha de indicar la operación y dos valores numéricos a tratar.*/
            String operando = Console.ReadLine();
            num1 = Console.ReadLine();
            num2 = Console.ReadLine();

            //Variable para comprobar sin cierre del programa, que las variables numericas son correctas
            double numerador1 = 0;
            double numerador2 = 0;

            //Dar al usuario la posibilidad de recibir ayuda si no sabe claramente como escribir el codigo
            if (operando == "help")
            {
                ShowHelp();
            }
            //Linea comprobante del correcto uso de los comandos
            else if (operando == null || !double.TryParse(num1, out numerador1) || !double.TryParse(num2, out numerador2))
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
                    else Console.WriteLine("Your result: {0:0.##}\n", resultado);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                
                Console.WriteLine("0\n");
                Console.WriteLine("Pulsa intro para finalizar el programa");
                Console.Read(); //Con el read podremos detener momentaneamente la consola
            }
        }

        private static void ShowError()
        {
            Console.WriteLine("Error: linea de comando mal formada.");
            ShowHelp();
        }

        private static void ShowHelp()
        {
            Console.WriteLine("USO:");

            Console.WriteLine("ConsoleCalculator [comand] [value1] [value2]");

            Console.WriteLine();

            Console.WriteLine("donde");
            Console.WriteLine("comand \t Comando add, sub, plus, div");
            Console.WriteLine("No olvide que el operando debe aparecer con guiones --add --sub --plus --div\n");
        }

        /*A de poder soportar al menos las operaciones suma, resta, multiplicación y división.*/
        private static void Add(double a, double b)
        {
            Console.WriteLine($"{a:N} + {b:N} = {a + b:N}");
            Console.WriteLine("El valor de sumar " + a + " y " + b + " daria como resultado: " + (a + b));
        }

        private static void Sub(double a, double b)
        {
            Console.WriteLine($"{a:N} - {b:N} = {a - b:N}");
            Console.WriteLine("El valor de restar " + a + " y " + b + " daria como resultado: " + (a - b));
        }

        private static void Plus(double a, double b)
        {
            Console.WriteLine($"{a:N} * {b:N} = {a * b:N}");
            Console.WriteLine("El valor de multiplicar " + a + " y " + b + " daria como resultado: " + (a * b));
        }

        private static void Div(double a, double b)
        {
            if (b == 0.0)
                Console.WriteLine("No se dividir entre 0");
            else
            {
                Console.WriteLine($"{a:N} / {b:N} = {a / b:N}");
                Console.WriteLine("El valor de dividir " + a + " y " + b + " daria como resultado: " + (a / b));
            }

        }
    }
}
