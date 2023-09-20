using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            fillMatrix(matrix);

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (rows == cols)
                    {
                        primaryDiagonalSum += matrix[rows, cols];
                    }
                    if (cols == n - 1 - rows)
                    {
                        secondaryDiagonalSum += matrix[rows, cols];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }

        private static void fillMatrix(int[,] matrix)
        {
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
        }
    }
}
