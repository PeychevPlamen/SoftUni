using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            int maxOrder = queue.Max();

            List<int> ordersLeft = new List<int>();

            while (queue.Count != 0)
            {
                int currOrder = queue.Peek();

                if (quantityFood >= currOrder)
                {
                    queue.Dequeue();
                    quantityFood -= currOrder;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(maxOrder);

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                while (queue.Count != 0)
                {
                    ordersLeft.Add(queue.Dequeue());
                }

                Console.WriteLine($"Orders left: {string.Join(" ", ordersLeft)}");
            }
        }
    }
}
