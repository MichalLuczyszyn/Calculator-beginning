using System.Diagnostics.CodeAnalysis;
using Calculator;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Calculator
{
    public class MathCalculations
    {
        public static void Calculate(int operation, double a, double b)
        {
            double solution = 0;
            switch (operation)
            {
                case 1:
                    solution = a + b;
                    Console.WriteLine("The result of the addition is: " + (solution));
                    break;
                case 2:
                    solution = a - b;
                    Console.WriteLine("The result of the subtraction is: " + (solution));
                    break;
                case 3:
                    solution = a * b;
                    Console.WriteLine("The result of the multiplication is: " + (solution));
                    break;
                case 4:
                    solution = a / b;
                    Console.WriteLine("The result of the division is: " + (solution));
                    break;
            }
            SaveSolutions(operation, a, b, solution);
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

        public static void SaveSolutions(int operation, double a, double b, double solution)
        {
            string output = Environment.NewLine + operation + " " + a + " " + b + ":" + solution;
            File.AppendAllText("C:\\Users\\micha\\source\\repos\\Calculator\\solutions.txt",output);
            Console.WriteLine("Solution saved.");
        }

        
        public static void CheckSolutions(int operation, double a, double b)
        {
            var output = operation + " " + a + " " + b;
            var solutions = File.ReadAllLines("C:\\Users\\micha\\source\\repos\\Calculator\\solutions.txt");
            var i = 1;
            int indexOfMark;
            var foundSolution = false;
            while (i < solutions.Length)
            {
                indexOfMark = solutions[i].IndexOf(':');
                if (indexOfMark != -1)
                {
                    var checkString = solutions[i].Substring(0 , indexOfMark);
                    if (checkString == output)
                    {
                        var solutionString = solutions[i].Substring(indexOfMark + 1);
                        Console.WriteLine("Found in file, solution: " + solutionString);
                        foundSolution = true;
                        break;
                    }
                }
                i++;
            }
            if (foundSolution != true) 
            {
                Console.WriteLine("Not found in file, calculating...");
                MathCalculations.Calculate(operation, a, b);
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
                double a = MathCalculations.CheckDoubleInput();

                Console.WriteLine("Choose the mathematical operation:");
                Console.WriteLine("Write 1 for add \n Write 2 for subtract \n Write 3 for multiply \n Write 4 for divide");
                int operation = MathCalculations.CheckOperationInput();
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
                double b = MathCalculations.CheckDoubleInput();
                
                while ((operation == 4) && (b == 0))
                {
                    Console.WriteLine("Error: You cannot divide by 0. Give a different number.");
                    b = MathCalculations.CheckDoubleInput();
                }
                MathCalculations.CheckSolutions(operation, a, b);                

                Console.WriteLine("Press Enter to start a new calculation.");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}