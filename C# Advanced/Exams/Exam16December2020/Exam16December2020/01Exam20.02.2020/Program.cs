using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Exam20._02._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfWaves = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> platesNums = new List<int>(platesInput.Reverse());

            Stack<int> plates = new Stack<int>(platesNums);

            bool isPlatesWins = false;
            List<int> orcss = new List<int>();

            for (int i = 1; i <= numOfWaves; i++)
            {
                int[] orcsInput = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

                Stack<int>orcs = new Stack<int>(orcsInput);

                Queue<int> curPlates = new Queue<int>();


                if (i % 3 == 0)
                {
                    int plateToAdd = int.Parse(Console.ReadLine());
                    curPlates.Enqueue(plateToAdd);

                    for (int j = 0; j < plates.Count; j++)
                    {
                        curPlates.Enqueue(plates.Pop());
                    }

                    plates = new Stack<int>(curPlates);
                }

                int tempPlate = plates.Pop();

                while (orcs.Count > 0)
                {
                    tempPlate -= orcs.Pop();

                }
                if (plates.Count > 0)
                {
                    isPlatesWins =  true;
                }
                foreach (var item in orcs)
                {
                    orcss.Add(item);
                }
            }
            if (isPlatesWins)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            if (orcss.Count > 0)
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", orcss)}");
            }
            else
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
