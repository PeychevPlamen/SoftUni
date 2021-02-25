using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char secondCh = char.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char curr = line[i];

                if (firstCh > secondCh)
                {
                    if (curr > secondCh && curr < firstCh)
                    {
                        sum += curr;
                    }
                }
                else
                {
                    if (curr < secondCh && curr > firstCh)
                    {
                        sum += curr;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
