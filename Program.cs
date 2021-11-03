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

            Console.WriteLine("Escriba, con un espaciado entre medias, el comando y los dos numeros a usar en la calculadora ");
            Console.WriteLine("escriba --help en caso de que no sepa como escribir los operandos");

            /*Se ha de indicar la operación y dos valores numéricos a tratar.*/
            var command = args[0];

            double.TryParse(args[1], out double value1);
            double.TryParse(args[2], out double value2);

            //Dar al usuario la posibilidad de recibir ayuda si no sabe claramente como escribir el codigo
            if (args.Length == 1 && args[0] == "--help")
            {
                ShowHelp();
            }
            else if (args.Length != 3)
            {
                ShowError();
                return;
            }
            else
            {
                switch (command)
                {
                    case "--add":
                        Add(value1, value2);
                        break;
                    case "--sub":
                        Sub(value1, value2);
                        break;
                    case "--plus":
                        Plus(value1, value2);
                        break;
                    case "--div":
                        Div(value1, value2);
                        break;
                    default:
                        ShowError();
                        break;
                }
                /*A de devolver 0 si el proceso termina correctamente y otro valor si se ha producido un error.*/
                Console.WriteLine("0");
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
            Console.WriteLine("El valor de sumar " + a + " y " + b + " daria como resultado: "+a + b);
        }

        private static void Sub(double a, double b)
        {
            Console.WriteLine($"{a:N} - {b:N} = {a - b:N}");
        }

        private static void Plus(double a, double b)
        {
            Console.WriteLine($"{a:N} * {b:N} = {a * b:N}");
        }

        private static void Div(double a, double b)
        {
            if (b == 0.0)
                Console.WriteLine("No se dividir entre 0");
            else
                Console.WriteLine($"{a:N} / {b:N} = {a / b:N}");
        }
    }
}
