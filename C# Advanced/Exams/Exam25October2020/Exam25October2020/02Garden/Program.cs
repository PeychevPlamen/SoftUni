using System;
using System.Linq;

namespace _02Garden
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

            string commands = Console.ReadLine();

            while (commands != "Bloom Bloom Plow")
            {
                int[] position = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = position[0];
                int col = position[1];

                if (!IsPositionValid(row, col, rows, cols))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int i = 0; i < cols; i++)
                    {
                        matrix[row, i] += 1;
                    }
                    for (int j = 0; j < rows; j++)
                    {
                        if (j != row)
                        {
                            matrix[j, col] += 1;
                        }

                    }
                }

                commands = Console.ReadLine();
            }

            printMatrix(matrix);
        }


        // fillMatrix char
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

        // printMatrix

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
        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
