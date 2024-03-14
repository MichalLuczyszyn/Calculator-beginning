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
                    if (b == 0)
                    {
                        Console.WriteLine("Error! You cannot divide by 0.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The result of the division is: " + (a / b));
                        break;
                    }
            }
        }

        public static void CheckOperations (int operation, double a, double b)
        {
            int i = 1;
            while (i <= 4)
            {
                if (operation == i)
                {
                    MathCalculations.Calculate(operation, a, b);
                    break;
                }
                i++;
            }
            if (i == 5)
            {
                Console.WriteLine("Error: Wrong operation: " + operation);
            }
        }

    }
    internal class Program
    {

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Calculator");
                Console.WriteLine("Let's give the first argument!");
                double a = 0;
                double b = 0;
                int operation = 0;
                bool ifError = false;
                try
                {
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Choose the mathematical operation:");
                    Console.WriteLine("Write 1 for add \n Write 2 for subtract \n Write 3 for multiply \n Write 4 for divide");
                    operation = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the second argument");
                    b = double.Parse(Console.ReadLine());
                
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid character!");
                    ifError = true;
                }
                if (ifError == false)
                {
                    MathCalculations.CheckOperations(operation, a, b);
                }
                Console.WriteLine("Press Enter to start a new calculation.");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}