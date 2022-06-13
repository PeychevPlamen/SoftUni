using System;
using System.Collections.Generic;

namespace Find_All_Paths_in_a_Labyrinth
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var labyrinth = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colElement = Console.ReadLine();

                for (int c = 0; c < colElement.Length; c++)
                {
                    labyrinth[r, c] = colElement[c];
                }
            }

            FindPaths(labyrinth, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] labyrinth, int row, int col, List<string> directions, string direction)
        {
            // check for out of matrix range
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            // check for already visited cell or for wall
            if (labyrinth[row, col] == 'v' || labyrinth[row, col] == '*')
            {
                return;
            }

            directions.Add(direction);

            // check for end
            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions).Trim());
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            labyrinth[row, col] = 'v';
            
            FindPaths(labyrinth, row - 1, col, directions, "U"); // Up
            FindPaths(labyrinth, row + 1, col, directions, "D"); // Down
            FindPaths(labyrinth, row, col + 1, directions, "R"); // Right
            FindPaths(labyrinth, row, col - 1, directions, "L"); // Left

            labyrinth[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
