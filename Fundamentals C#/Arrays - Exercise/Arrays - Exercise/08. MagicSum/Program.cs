using System;
using System.Linq;

namespace _08._MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int num = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    sum = arr[i] + arr[j];

                    if (sum == num)
                    {
                        Console.WriteLine($"{arr[i]} {arr[j]}");
                    }
                }
            }
        }
    }
}
