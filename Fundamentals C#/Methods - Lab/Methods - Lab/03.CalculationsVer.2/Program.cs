using System;
using System.ComponentModel;

namespace _03.CalculationsVer._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                Add(firstNum, secondNum);
            }
            else if (command == "multiply")
            {
                Multiply(firstNum, secondNum);
            }
            else if (command == "subtract")
            {
                Subtract(firstNum, secondNum);
            }
            else if (command == "divide")
            {
                Divide(firstNum, secondNum);
            }
        }

        private static void Divide(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }

        private static void Subtract(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }

        private static void Multiply(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }

        private static void Add(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }
    }
}
