using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] numbers = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(double.Parse)
                                          .ToArray();

                matrix[row] = numbers;

            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string inputCommand = Console.ReadLine();

            while (inputCommand != "End")
            {
                string[] commands = inputCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = commands[0];
                int currRow = int.Parse(commands[1]);
                int currCol = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (currRow >= 0 
                    && currRow < matrix.Length 
                    && currCol >=0 
                    && currCol <= matrix.Length)
                {
                    if (currCmd == "Add")
                    {
                        matrix[currRow][currCol] += value;
                    }
                    else
                    {
                        matrix[currRow][currCol] -= value;
                    }
                }
                else
                {
                    inputCommand = Console.ReadLine();
                    continue;
                }

                inputCommand = Console.ReadLine();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" " , item));
            }
        }
    }
}
