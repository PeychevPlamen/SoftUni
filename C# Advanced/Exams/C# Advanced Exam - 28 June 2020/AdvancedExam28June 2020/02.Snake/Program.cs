using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            fillMatrix(matrix);

            string commands = Console.ReadLine();

            int snakeRow = 0;
            int snakeCol = 0;

            int foodEaten = 0;

            //find where is the snake
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';

                snakeRow = MoveRow(snakeRow, commands);
                snakeCol = MoveCol(snakeCol, commands);

                if (!IsPositionValid(snakeRow, snakeCol, sizeMatrix, sizeMatrix))
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    // find where is the second burrow
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                snakeRow = row;
                                snakeCol = col;
                            }
                        }
                    }

                }
                matrix[snakeRow, snakeCol] = 'S';

                if (foodEaten >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    break;
                }

                commands = Console.ReadLine();
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
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
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
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }
        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }

    }
}
