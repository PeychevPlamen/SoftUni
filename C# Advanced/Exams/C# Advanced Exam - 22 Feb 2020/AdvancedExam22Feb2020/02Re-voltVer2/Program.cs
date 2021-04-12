using System;

namespace _02Re_voltVer2
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

            bool isWin = false;

            // find where 'f' is
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

            for (int i = 0; i < numOfCommands; i++)
            {
                matrix[playerRow, playerCol] = '-';

                string commands = Console.ReadLine();

                playerRow = MoveRow(playerRow, commands);
                playerCol = MoveCol(playerCol, commands);

                if (!IsPositionValid(playerRow, playerCol, size, size))
                {
                    if (commands == "left")
                    {
                        //playerCol = MoveRow(size - 1, commands);
                        playerCol = size - 1;
                    }
                    else if (commands == "right")
                    {
                        //playerCol = MoveRow(0, commands);
                        playerCol = 0;
                    }
                    else if (commands == "up")
                    {
                        // playerRow = MoveCol(size - 1, commands);
                        playerRow = size - 1;
                    }
                    else if (commands == "down")
                    {
                        //playerRow = MoveCol(0, commands);
                        playerRow = 0;
                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWin = true;
                        break;
                    }

                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow = MoveRow(playerRow, commands);
                    playerCol = MoveCol(playerCol, commands);

                    if (!IsPositionValid(playerRow, playerCol, size, size))
                    {
                        if (commands == "left")
                        {
                            //playerCol = MoveRow(size - 1, commands);
                            playerCol = size - 1;
                        }
                        else if (commands == "right")
                        {
                            //playerCol = MoveRow(0, commands);
                            playerCol = 0;
                        }
                        else if (commands == "up")
                        {
                            // playerRow = MoveCol(size - 1, commands);
                            playerRow = size - 1;
                        }
                        else if (commands == "down")
                        {
                            //playerRow = MoveCol(0, commands);
                            playerRow = 0;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWin = true;
                        break;
                    }
                    //matrix[playerRow, playerCol] = 'f';

                }

                if (matrix[playerRow, playerCol] == 'T')
                {
                    if (commands == "left" || commands == "right")
                    {
                        //playerCol = MoveCol(playerCol - 2, commands);
                        playerCol -= 1;
                    }
                    else
                    {
                        //playerRow = MoveRow(playerRow - 2, commands);
                        playerRow -= 1;
                    }
                    if (!IsPositionValid(playerRow, playerCol, size, size))
                    {
                        if (commands == "left")
                        {
                            //playerCol = MoveRow(size - 1, commands);
                            playerCol = size - 1;
                        }
                        else if (commands == "right")
                        {
                            //playerCol = MoveRow(0, commands);
                            playerCol = 0;
                        }
                        else if (commands == "up")
                        {
                            // playerRow = MoveCol(size - 1, commands);
                            playerRow = size - 1;
                        }
                        else if (commands == "down")
                        {
                            //playerRow = MoveCol(0, commands);
                            playerRow = 0;
                        }
                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWin = true;
                        break;
                    }

                    matrix[playerRow, playerCol] = 'f';

                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    isWin = true;
                    break;
                }

                matrix[playerRow, playerCol] = 'f';

            }
            if (isWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

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
