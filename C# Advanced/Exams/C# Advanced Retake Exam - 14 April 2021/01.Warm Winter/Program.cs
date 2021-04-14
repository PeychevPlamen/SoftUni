using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hatsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] scarfInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sets = 0;

            Stack<int> hats = new Stack<int>(hatsInput);
            Queue<int> scarfs = new Queue<int>(scarfInput);

            int tempHats = 0;
            int tempScarfs = 0;
            int sum = 0;

            List<int> mostExpensive = new List<int>();

            while (scarfs.Count != 0 && hats.Count != 0)
            {
                tempHats = hats.Peek();
                tempScarfs = scarfs.Peek();

                if (tempHats > tempScarfs)
                {
                    sets++;
                    sum = tempHats + tempScarfs;
                    mostExpensive.Add(sum);
                    hats.Pop();
                    scarfs.Dequeue();

                }
                else if (tempScarfs > tempHats)
                {
                    hats.Pop();
                }
                else if (tempScarfs == tempHats)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(tempHats + 1);
                }

            }

            Console.WriteLine($"The most expensive set is: {mostExpensive.Max()}");
            Console.WriteLine(string.Join(" ", mostExpensive));
        }
    }
}
