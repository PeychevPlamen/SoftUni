using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int numOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            fillMatrix(matrix);

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool isFinished = false;

            for (int i = 0; i < numOfCommands; i++)
            {
                string commands = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                int tempRow = playerRow;
                int tempCol = playerCol;

                playerRow = MoveRow(playerRow, commands);
                playerCol = MoveCol(playerCol, commands);

                if (IsPositionValid(playerRow, playerCol, size, size) == false)
                {
                    if (commands == "left")
                    {
                        playerCol = size - 1;
                    }
                    else if (commands == "right")
                    {
                        playerCol = 0;
                    }
                    else if (commands == "up")
                    {
                        playerRow = size - 1;
                    }
                    else if (commands == "down")
                    {
                        playerRow = 0;
                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isFinished = true;
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        break;
                    }

                }

                else
                {
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow = MoveRow(playerRow, commands);
                        playerCol = MoveCol(playerCol, commands);

                        if (IsPositionValid(playerRow, playerCol, size, size) == false)
                        {
                            if (commands == "left")
                            {
                                playerCol = size - 1;
                            }
                            else if (commands == "right")
                            {
                                playerCol = 0;
                            }
                            else if (commands == "up")
                            {
                                playerRow = size - 1;
                            }
                            else if (commands == "down")
                            {
                                playerRow = 0;
                            }

                        }

                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        if (commands == "left")
                        {
                            playerCol++;
                        }
                        else if (commands == "right")
                        {
                            playerCol--;
                        }
                        else if (commands == "up")
                        {
                            playerRow++;
                        }
                        else if (commands == "down")
                        {
                            playerRow--;
                        }
                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isFinished = true;
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        break;
                    }

                }

                matrix[playerRow, playerCol] = 'f';

            }

            if (isFinished == false)
            {
                Console.WriteLine("Player lost!");
            }

            printMatrix(matrix);
        }

        //fillMatrix char

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

        // positionValid
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
