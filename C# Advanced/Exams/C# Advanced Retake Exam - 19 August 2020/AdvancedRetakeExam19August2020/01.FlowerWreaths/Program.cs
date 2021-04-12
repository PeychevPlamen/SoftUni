using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rosesInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(liliesInput);
            Queue<int> roses = new Queue<int>(rosesInput);

            int sumFlowers = 0;
            int wreaths = 0;
            int liliesDecreaseNum = 0;
            int flowersLeft = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                sumFlowers = lilies.Peek() + roses.Peek();

                if (sumFlowers == 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    wreaths++;
                }
                else if (sumFlowers > 15)
                {
                    liliesDecreaseNum = lilies.Pop() - 2;
                    lilies.Push(liliesDecreaseNum);
                }
                else
                {
                    flowersLeft += lilies.Pop() + roses.Dequeue();
                }
            }
            wreaths += flowersLeft / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
