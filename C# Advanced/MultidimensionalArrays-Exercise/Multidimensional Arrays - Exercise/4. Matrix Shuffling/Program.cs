using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            fillMatrix(matrix);
            // printMatrix(matrix);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands.Length == 5)
                {
                    string currCmd = commands[0];
                    int oldRow = int.Parse(commands[1]);
                    int oldCol = int.Parse(commands[2]);
                    int newRow = int.Parse(commands[3]);
                    int newCol = int.Parse(commands[4]);

                    if (currCmd == "swap" && oldRow <= size[0] && oldCol <= size[1]
                        && oldRow >= 0 && oldCol >= 0 && newRow <= size[0] && newCol <= size[1]
                        && newRow >= 0 && newCol >= 0)
                    {
                        string firstElement = matrix[oldRow, oldCol];
                        string secondElement = matrix[newRow, newCol];

                        matrix[oldRow, oldCol] = secondElement;
                        matrix[newRow, newCol] = firstElement;

                        //for (int row = 0; row < matrix.GetLength(0); row++)
                        //{
                        //    for (int col = 0; col < matrix.GetLength(1); col++)
                        //    {
                        //        if (oldRow == row && oldCol == col)
                        //        {
                        //            matrix[row, col] = secondElement;
                        //        }
                        //        else if (row == newRow && col == newCol)
                        //        {
                        //            matrix[row, col] = firstElement;
                        //        }
                        //    }
                        //}
                        printMatrix(matrix);
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }


        }
        private static void printMatrix(string[,] matrix)
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

        private static void fillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
