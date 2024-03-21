

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
                    Console.WriteLine("The result of the addition is: " + solution);
                    break;
                case 2:
                    solution = a - b;
                    Console.WriteLine("The result of the subtraction is: " + solution);
                    break;
                case 3:
                    solution = a * b;
                    Console.WriteLine("The result of the multiplication is: " + solution);
                    break;
                case 4:
                    solution = a / b;
                    Console.WriteLine("The result of the division is: " + solution);
                    break;
                case 5:
                    solution = 1;
                    var i = 1;
                    while ((a > 0) && (i <= a))
                    {
                        solution *= i;
                        i++;
                    }
                    Console.WriteLine("The result of the factorial is: " + solution);
                    break;
                case 6:
                    solution = a % b;
                    Console.WriteLine("The result of modulo is: " + solution);
                    break;
            }
            SaveSolutions(operation, a, b, solution);
        }


        public static double CheckDoubleInput ()
        {
            var input = Console.ReadLine();
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
            var input = Console.ReadLine();
            int result;
            var operationsSum = 6;
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
                    var i = 1;
                    while (i <= operationsSum)
                    {
                        if (result == i)
                        {
                            return result;
                        }
                        i++;
                        if (i == operationsSum + 1)
                        {
                            Console.WriteLine("Error: Wrong operation: " + result + ". Try again.");
                            input = Console.ReadLine();
                        }
                    }
                }
            }
        }

        public static int CheckFactorialInput(double a)
        {
            while ((a != Convert.ToInt32(a)) || (a < 0))
            {
                Console.WriteLine("Error: Invalid character to factorial. Try again.");
                a = CheckDoubleInput();
            }
            return Convert.ToInt32(a);
        }

        public static void SaveSolutions(int operation, double a, double b, double solution)
        {
            var output = Environment.NewLine + operation + " " + a + " " + b + ":" + solution;
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "solutions.txt");
            File.AppendAllText(file, output);
            Console.WriteLine("Solution saved.");
        }

        
        public static void CheckSolutions(int operation, double a, double b)
        {
            var output = operation + " " + a + " " + b;
            var foundSolution = false;
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "solutions.txt");
            if (File.Exists(file))
            {
                var solutions = File.ReadAllLines(file);
                var i = 1;
                int indexOfMark;
                while (i < solutions.Length)
                {
                    indexOfMark = solutions[i].IndexOf(':');
                    if (indexOfMark != -1)
                    {
                        var checkString = solutions[i].Substring(0, indexOfMark);
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
                var a = MathCalculations.CheckDoubleInput();

                List<string> operationList = new() { "add", "substract", "multiply", "divide", "factorial", "modulo" };
                Console.WriteLine("Choose the mathematical operation:");
                for (var i = 1; i < operationList.Count+1; i++)
                {
                    Console.WriteLine("Write " + i + " for " + operationList[i - 1]);
                }
                var operation = MathCalculations.CheckOperationInput();
                Console.WriteLine("Chosen operation: " + operationList[operation - 1]);

                double b;
                if (operation != 5)
                {
                    Console.WriteLine("Enter the second argument");
                    b = MathCalculations.CheckDoubleInput();
                }
                else
                {
                    b = 0;
                    a = MathCalculations.CheckFactorialInput(a);
                }

                while (((operation == 4) || (operation == 6)) && (b == 0))
                {
                    Console.WriteLine("Error: You cannot divide or modulo by 0. Give a different number.");
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