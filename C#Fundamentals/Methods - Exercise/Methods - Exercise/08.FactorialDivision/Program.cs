using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine($"{DevideFirstFactorialBySecond(firstNum, secondNum):f2}");
        }
        
        private static double DevideFirstFactorialBySecond(int firstNum, int secondNum)
        {
            double firstFctorial = 1;
            double secondFactorial = 1;

            for (int i = 1; i <= firstNum; i++)
            {
                firstFctorial *= i;
            }
            for (int j = 1; j <= secondNum; j++)
            {
                secondFactorial *= j;
            }

            double divideNum = firstFctorial / secondFactorial;

            return divideNum;
        }
    }
}
