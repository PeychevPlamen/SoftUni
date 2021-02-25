using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = Sum(firstNum, secondNum, thirdNum);

            Console.WriteLine(sum);
        }

        private static int Sum(int firstNum, int secondNum, int thirdNum)
        {
            int sumFirstAndSecond = firstNum + secondNum;
            return Subtract(sumFirstAndSecond, thirdNum);
        }

        private static int Subtract(int sumFirstAndSecond, int thirdNum)
        {
            return sumFirstAndSecond - thirdNum;
        }
    }
}
