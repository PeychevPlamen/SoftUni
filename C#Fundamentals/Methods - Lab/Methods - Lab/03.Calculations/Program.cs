using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            
            PrintResult(command);

        }

        private static void PrintResult(string command)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            double result = 0;

            if (command == "add")
            {
                result = firstNum + secondNum;
            }
            else if (command == "multiply")
            {
                result = firstNum * secondNum;
            }
            else if (command == "subtract")
            {
                result = firstNum - secondNum;
            }
            else if (command == "divide")
            {
                result = firstNum / secondNum;
            }

            Console.WriteLine(result);
        }
    }
}
