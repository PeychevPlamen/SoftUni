using System;

namespace _02._SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;

            while (input != 0)
            {
                int num = input % 10;
                sum += num;
                int currentNum = input / 10;
                input = currentNum;
            }
            Console.WriteLine(sum);
        }
    }
}
