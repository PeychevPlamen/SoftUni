using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            int rows = sizeMatrix[0];
            int cols = sizeMatrix[1];

            int[,] matrix = new int[rows, cols];

            fillMatrix(matrix);

            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                int[] currPosition = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = currPosition[0];
                int col = currPosition[1];

                if (row <= rows && col <= cols)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        matrix[row, i] += 1;
                    }
                    for (int i = 0; i < rows; i++)
                    {
                        if (i != row)
                        {
                            matrix[i, col] += 1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine();
            }

            printMatrix(matrix);
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
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
    }
}
