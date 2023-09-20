using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombCasingInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffecs = new Queue<int>(bombEffectsInput);
            Stack<int> bombCasing = new Stack<int>(bombCasingInput);

            int datura = 0;
            int cherry = 0;
            int smokeDecoy = 0;

            bool bombPouch = false;
            
            while (true)
            {
                int sum = bombEffecs.Peek() + bombCasing.Peek();

                if (sum == 40)
                {
                    datura++;
                    bombEffecs.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == 60)
                {
                    cherry++;
                    bombEffecs.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == 120)
                {
                    smokeDecoy++;
                    bombEffecs.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    int tempChasing = bombCasing.Pop() - 5;
                    bombCasing.Push(tempChasing);
                }
                if (datura >= 3 && cherry >= 3 && smokeDecoy >= 3)
                {
                    bombPouch = true;
                    break;
                }
                if (bombEffecs.Count == 0 || bombCasing.Count == 0)
                {
                    break;
                }
            }
            if (bombPouch)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffecs.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffecs)}");
            }
            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoy}");
        }
    }
}
