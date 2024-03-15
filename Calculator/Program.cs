using System.Diagnostics.CodeAnalysis;
using Calculator;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator
{
    public class MathCalculations
    {
        public static void Calculate(int operation, double a, double b)
        {
            switch (operation)
            {
                case 1:
                    Console.WriteLine("The result of the addition is: " + (a + b));
                    break;
                case 2:
                    Console.WriteLine("The result of the subtraction is: " + (a - b));
                    break;
                case 3:
                    Console.WriteLine("The result of the multiplication is: " + (a * b));
                    break;
                case 4:
                    Console.WriteLine("The result of the division is: " + (a / b));
                    break;
            }
        }


        public static double CheckDoubleInput ()
        {
            string input = Console.ReadLine();
            double result;
            while (!double.TryParse(input, out result))
            {
                Console.WriteLine("Error: Invalid character. Try again.");
                input = Console.ReadLine();
            }
            result = double.Parse(input);
            return result;
        }


        public static int CheckOperationInput()
        {
            string input = Console.ReadLine();
            int result;
            while (true)
            {
                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Error: Invalid character. Try again.");
                    input = Console.ReadLine();
                }
                else
                {
                    result = int.Parse(input);
                    int i = 1;
                    while (i <= 4)
                    {
                        if (result == i)
                        {
                            return result;
                        }
                        i++;
                        if (i == 5)
                        {
                            Console.WriteLine("Error: Wrong operation: " + result + ". Try again.");
                            input = Console.ReadLine();
                        }
                    }
                }
            }
        }


    }
    internal class Program
    {

        private static void Main(string[] args)
        {
            while (true)
            {
                double a;
                double b;
                int operation = 0;
                Console.WriteLine("Welcome to Calculator");

                Console.WriteLine("Let's give the first argument!");
                a = MathCalculations.CheckDoubleInput();

                Console.WriteLine("Choose the mathematical operation:");
                Console.WriteLine("Write 1 for add \n Write 2 for subtract \n Write 3 for multiply \n Write 4 for divide");
                operation = MathCalculations.CheckOperationInput();
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Chosen operation: add");
                        break;
                    case 2:
                        Console.WriteLine("Chosen operation: substract");
                        break;
                    case 3:
                        Console.WriteLine("Chosen operation: multiply");
                        break;
                    case 4:
                        Console.WriteLine("Chosen operation: divide");
                        break;
                }

                Console.WriteLine("Enter the second argument");
                b = MathCalculations.CheckDoubleInput();
                
                while ((operation == 4) && (b == 0))
                {
                    Console.WriteLine("Error: You cannot divide by 0. Give a different number.");
                    b = MathCalculations.CheckDoubleInput();
                }
                MathCalculations.Calculate(operation, a, b);

                Console.WriteLine("Press Enter to start a new calculation.");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}