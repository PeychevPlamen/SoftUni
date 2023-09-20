using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new int[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] commands = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currCmd = commands[0];
                int currRow = int.Parse(commands[1]);
                int currCol = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (matrix.Length <= currRow || currRow < 0 
                    || matrix[currRow].Length <= currCol || currCol < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (currCmd == "Add")
                    {
                        matrix[currRow][currCol] += value;
                    }
                    else if (currCmd == "Subtract")
                    {
                        matrix[currRow][currCol] -= value;
                    }
                    
                }
                
                cmd = Console.ReadLine();
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" " , row));
            }
        }
    }
}
