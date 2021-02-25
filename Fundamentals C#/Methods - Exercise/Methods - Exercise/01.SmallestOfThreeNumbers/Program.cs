using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            SmallestOfThreeNumbers(firstNum, secondNum, thirdNum);
        }

        private static void SmallestOfThreeNumbers(int firstNum, int secondNum, int thirdNum)
        {
            int minNum = Math.Min(firstNum, Math.Min(secondNum, thirdNum));

            //int minNum = 0;
            //if (firstNum < secondNum && firstNum < thirdNum )
            //{
            //    minNum = firstNum;
            //}
            //else if (secondNum < firstNum && secondNum < thirdNum)
            //{
            //    minNum = secondNum;
            //}
            //else if (thirdNum < firstNum && thirdNum < secondNum)
            //{
            //    minNum = thirdNum;
            //}
            //else
            //{
            //    minNum = firstNum;
            //}
            
            Console.WriteLine(minNum);
        }
    }
}
