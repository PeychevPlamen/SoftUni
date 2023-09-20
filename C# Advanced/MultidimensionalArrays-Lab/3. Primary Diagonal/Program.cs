using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;

            for (int r = 0; r < matrix.GetLength(1); r++)
            {
                for (int c = 0; c < matrix.GetLength(0); c++)
                {
                    if (r == c)
                    {
                        sum += matrix[r, c];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
