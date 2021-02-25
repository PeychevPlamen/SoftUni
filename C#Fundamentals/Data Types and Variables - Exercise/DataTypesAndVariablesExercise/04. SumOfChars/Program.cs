using System;

namespace _04._SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i <= num; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sum += (int)input;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
