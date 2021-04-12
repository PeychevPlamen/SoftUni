using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxQueue = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondBoxStack = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstLootBox = new Queue<int>(firstBoxQueue);

            Stack<int> secondLootBox = new Stack<int>(secondBoxStack);

            int value = 0;

            while (firstLootBox.Count != 0 && secondLootBox.Count != 0)
            {
                int currFirsBoxNum = firstLootBox.Peek();
                int currSecondBoxNum = secondLootBox.Peek();

                int sum = currFirsBoxNum + currSecondBoxNum;

                if (sum % 2 == 0)
                {
                    value += sum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    secondLootBox.Pop();
                    firstLootBox.Enqueue(currSecondBoxNum);
                }
            }
            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (value >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {value}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {value}");
            }
        }
    }
}
