using System;
using System.Collections.Generic;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            fillMatrix(matrix);

            int sRow = 0;
            int sCol = 0;
            string commands = Console.ReadLine();
            int money = 0;
            
            List<char> numbers = new List<char> {'0', '1', '2', '4', '5', '6', '7', '8', '9' };

            // find where S is
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }

            while (true)
            {
                matrix[sRow, sCol] = '-';

                sRow = MoveRow(sRow, commands);
                sCol = MoveCol(sCol, commands);

                if (!IsPositionValid(sRow, sCol, n, n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    break;
                }

                char currSymbol = matrix[sRow, sCol];

                if (numbers.Contains(currSymbol))
                {
                    money += int.Parse(currSymbol.ToString());
                }
                if (currSymbol == 'O')
                {
                    matrix[sRow, sCol] = '-';

                    // find where second 'O' is
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                sRow = row;
                                sCol = col;
                            }
                        }
                    }
                }

                matrix[sRow, sCol] = 'S';

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {money}");
                    break;
                }
                commands = Console.ReadLine();
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
