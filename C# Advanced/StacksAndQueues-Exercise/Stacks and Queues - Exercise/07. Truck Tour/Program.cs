using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                queue.Enqueue(input);
            }

            int totalPetrol = 0;

            for (int j = 0; j < queue.Count; j++)
            {
                string currPump = queue.Dequeue();

                int[] pumpInfo = currPump.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

                int amountPetrol = pumpInfo[0];
                int distance = pumpInfo[1];
                int index = pumpInfo[2];

                totalPetrol += amountPetrol;

                if (totalPetrol >= distance)
                {
                    totalPetrol -= distance;
                }
                else
                {
                    totalPetrol = 0;
                    j = -1;
                }
                queue.Enqueue(currPump);
            }

            string[] firstElement = queue.Peek().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(firstElement[2]);
        }
    }
}
