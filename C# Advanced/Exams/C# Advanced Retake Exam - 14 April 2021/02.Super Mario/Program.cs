using System;
using System.Linq;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLivesMario = int.Parse(Console.ReadLine());

            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }

            }

            int rowMario = 0;
            int colMario = 0;

            int tempRow = 0;
            int tempCol = 0;

            bool isDeath = false;
            bool safeQueen = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        rowMario = row;
                        colMario = col;
                    }
                }
            }

            while (true)
            {
                string[] commandsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                tempRow = rowMario;
                tempCol = colMario;

                string command = commandsInput[0];
                int rowEnemy = int.Parse(commandsInput[1]);
                int colEnemy = int.Parse(commandsInput[2]);

                matrix[rowEnemy][colEnemy] = 'B';

                matrix[rowMario][colMario] = '-';

                rowMario = MoveRow(rowMario, command);
                colMario = MoveCol(colMario, command);
                countLivesMario--;

                if (countLivesMario <= 0)
                {
                    isDeath = true;
                    matrix[rowMario][colMario] = 'X';
                    break;
                }

                if (!IsPositionValid(rowMario, colMario, size, size))
                {
                    rowMario = tempRow;
                    colMario = tempCol;

                    if (countLivesMario <= 0)
                    {
                        isDeath = true;
                        matrix[rowMario][colMario] = 'X';
                        break;
                    }

                }

                if (matrix[rowMario][colMario] == 'B')
                {
                    countLivesMario -= 2;

                    if (countLivesMario <= 0)
                    {
                        isDeath = true;
                        matrix[rowMario][colMario] = 'X';
                        break;
                    }

                    matrix[rowMario][colMario] = '-';
                }
                if (matrix[rowMario][colMario] == 'P')
                {

                    matrix[rowMario][colMario] = '-';
                    safeQueen = true;
                    break;
                }

                matrix[rowMario][colMario] = 'M';

            }

            if (isDeath)
            {
                Console.WriteLine($"Mario died at {rowMario};{colMario}.");
            }
            else if (safeQueen)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {countLivesMario}");
            }

            printMatrix(matrix);
        }


        // printMatrix

        private static void printMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
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
            if (movement == "W")
            {
                return row - 1;
            }
            if (movement == "S")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "A")
            {
                return col - 1;
            }
            if (movement == "D")
            {
                return col + 1;
            }

            return col;
        }
    }
}
