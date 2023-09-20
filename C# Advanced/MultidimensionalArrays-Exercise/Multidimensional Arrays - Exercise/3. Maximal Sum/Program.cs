using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];
            fillMatrix(matrix);
            //printMatrix(matrix);
            int maxSum = int.MinValue;
            int currSum = 0;
            int bestRowIndex = 0;
            int bestColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                            + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                            + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        bestRowIndex = row;
                        bestColIndex = col;

                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");

            for (int r = bestRowIndex; r < bestRowIndex + 3; r++)
            {
                for (int c = bestColIndex; c < bestColIndex + 3; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void printMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void fillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
