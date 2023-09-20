using System;
using System.Linq;

namespace _5._Snake_Moves
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

            char[,] matrix = new char[rows, cols];

            string input = Console.ReadLine();

            int currentLetter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = input[currentLetter];
                        currentLetter++;

                        if (currentLetter == input.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = input[currentLetter];
                        currentLetter++;

                        if (currentLetter == input.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }

            }
            printMatrix(matrix);

        }
        private static void printMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
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
