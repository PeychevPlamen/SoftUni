using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputBombEffect = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputBombCasing = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffect = new Queue<int>(inputBombEffect);

            Stack<int> bombCasing = new Stack<int>(inputBombCasing);

            int daturaBombs = 40;
            int cherryBombs = 60;
            int smokeDecoyBombs = 120;

            int sum = 0;

            int cherryBombCount = 0;
            int daturaBombCount = 0;
            int smokeBombCount = 0;

            int decreaseBombCasing = 0;
            bool isFill = false;

            while (true)
            {
                sum = bombEffect.Peek() + bombCasing.Peek();

                if (sum == daturaBombs)
                {
                    daturaBombCount++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == cherryBombs)
                {
                    cherryBombCount++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == smokeDecoyBombs)
                {
                    smokeBombCount++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    decreaseBombCasing = bombCasing.Pop() - 5;
                    bombCasing.Push(decreaseBombCasing);
                }

                if (cherryBombCount >= 3 && daturaBombCount >= 3 && smokeBombCount >= 3)
                {
                    isFill = true;
                    break;
                }

                if (bombEffect.Count == 0 || bombCasing.Count == 0)
                {
                    break;
                }
            }

            if (isFill)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }

            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombCount}");
        }
    }
}
