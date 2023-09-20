using System;
using System.Linq;

namespace _2._Squares_in_Matrix
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

            char[,] matrix = new char[rows, cols];
            fillMatrix(matrix);

            int numsOfSquares = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row + 1, col] == matrix[row + 1, col + 1]
                        && matrix[row, col] == matrix[row + 1, col])
                    {
                        numsOfSquares++;
                    }
                }
            }
            Console.WriteLine(numsOfSquares);

        }

        private static void printMatrix(char[,] matrix)
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

        private static void fillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(char.Parse)
                                     .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
