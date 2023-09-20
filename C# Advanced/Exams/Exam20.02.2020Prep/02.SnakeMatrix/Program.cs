using System;

namespace _02.SnakeMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            fillMatrix(matrix);

            int snakeRow = 0;
            int snakeCol = 0;
            int foodEaten = 0;

            // find snake position

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';

                snakeRow = MoveRow(snakeRow, commands);
                snakeCol = MoveCol(snakeCol, commands);

                if (!IsPositionValid(snakeRow, snakeCol, size, size))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

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

                    matrix[snakeRow, snakeCol] = 'S';
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                if (foodEaten >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    matrix[snakeRow, snakeCol] = 'S';
                    break;
                }

                matrix[snakeRow, snakeCol] = 'S';

                commands = Console.ReadLine();
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            printMatrix(matrix);
        }

        // fillMatrix char
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

        // printMatrix
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
