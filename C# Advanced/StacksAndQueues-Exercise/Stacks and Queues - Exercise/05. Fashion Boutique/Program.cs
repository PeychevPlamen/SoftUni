using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(clothes);

            int countRacks = 1;
            int value = capacity;

            while (box.Count > 0)
            {
                int currClothes = box.Peek();

                if (currClothes <= value)
                {
                    value -= box.Pop();
                }
                else
                {
                    value = capacity;
                    countRacks++;
                }
            }

            Console.WriteLine(countRacks);
        }
    }
}
