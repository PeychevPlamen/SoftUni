using System;
using System.Linq;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int commandsNum = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            fillMatrix(matrix);

            int rowPlayer = 0;
            int colPlayer = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                }
            }

            bool isWinner = false;

            for (int i = 0; i < commandsNum; i++)
            {
                string commands = Console.ReadLine();
                matrix[rowPlayer, colPlayer] = '-';

                if (commands == "down")
                {
                    rowPlayer += 1;

                    if (rowPlayer > matrix.GetLength(0))
                    {
                        if (matrix[0, colPlayer] == 'B')
                        {
                            matrix[1, colPlayer] = 'f';

                        }
                        else if (matrix[0, colPlayer] == 'T')
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                        else
                        {
                            matrix[0, colPlayer] = 'f';
                        }
                    }
                    else
                    {
                        if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            rowPlayer += 1;

                            if (matrix[rowPlayer, colPlayer] == 'F')
                            {
                                isWinner = true;
                                matrix[rowPlayer, colPlayer] = 'f';
                                break;
                            }
                            else
                            {
                                matrix[rowPlayer, colPlayer] = 'f';
                            }
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            matrix[rowPlayer - 1, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            isWinner = true;
                            matrix[rowPlayer, colPlayer] = 'f';
                            break;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';

                        }

                    }

                }
                else if (commands == "up")
                {
                    rowPlayer -= 1;

                    if (rowPlayer < 0)
                    {
                        rowPlayer = sizeMatrix - 1;

                        if (matrix[rowPlayer, colPlayer] == 'B')
                        {

                            matrix[0, colPlayer] = 'f';

                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            matrix[0, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            isWinner = true;
                            matrix[rowPlayer, colPlayer] = 'f';
                            break;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                    else
                    {

                        if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            rowPlayer += 1;

                            if (matrix[rowPlayer, colPlayer] == 'F')
                            {
                                isWinner = true;
                                matrix[rowPlayer, colPlayer] = 'f';
                                break;
                            }
                            else
                            {
                                matrix[rowPlayer, colPlayer] = 'f';
                            }
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            matrix[rowPlayer + 1, colPlayer] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            isWinner = true;
                            matrix[rowPlayer, colPlayer] = 'f';
                            break;
                        }
                        else
                        {

                            matrix[rowPlayer, colPlayer] = 'f';

                        }

                    }

                }
                else if (commands == "left")
                {
                    colPlayer -= 1;

                    if (colPlayer < 0)
                    {
                        colPlayer = sizeMatrix - 1;

                        if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer - 1] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            matrix[rowPlayer, 0] = 'f';
                            colPlayer += 1;
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            isWinner = true;
                            matrix[rowPlayer, colPlayer] = 'f';
                            break;
                        }

                    }
                    else
                    {
                        if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            if (colPlayer == 0)
                            {
                                colPlayer = sizeMatrix - 1;
                                matrix[rowPlayer, colPlayer] = 'f';
                            }
                            else
                            {
                                matrix[rowPlayer, colPlayer - 1] = 'f';
                            }

                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            colPlayer += 1;
                            matrix[rowPlayer, colPlayer] = 'f';

                        }
                        else if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            isWinner = true;
                            matrix[rowPlayer, colPlayer] = 'f';
                            break;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }

                    }

                }
                else if (commands == "right")
                {
                    colPlayer += 1;

                    if (colPlayer > sizeMatrix - 1)
                    {
                        colPlayer = 0;

                        if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            matrix[rowPlayer, colPlayer + 1] = 'f';
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            matrix[rowPlayer, sizeMatrix - 1] = 'f';
                            colPlayer -= 1;
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            isWinner = true;
                            matrix[rowPlayer, colPlayer] = 'f';
                            break;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }
                    else
                    {
                        if (matrix[rowPlayer, colPlayer] == 'B')
                        {
                            colPlayer += 1;

                            if (matrix[rowPlayer, colPlayer] == 'F')
                            {
                                isWinner = true;
                                matrix[rowPlayer, colPlayer] = 'f';
                                break;
                            }
                            else
                            {
                                matrix[rowPlayer, colPlayer] = 'f';
                            }

                        }
                        else if (matrix[rowPlayer, colPlayer] == 'T')
                        {
                            matrix[rowPlayer, colPlayer - 1] = 'f';
                            colPlayer -= 1;
                        }
                        else if (matrix[rowPlayer, colPlayer] == 'F')
                        {
                            isWinner = true;
                            matrix[rowPlayer, colPlayer] = 'f';
                            break;
                        }
                        else
                        {
                            matrix[rowPlayer, colPlayer] = 'f';
                        }
                    }

                }

            }
            if (isWinner)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
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
    }
}
