using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            fillMatrix(matrix);

            string commands = Console.ReadLine();

            int beeRow = 0;
            int beeCol = 0;
            int pollinatedFlowers = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }


            while (commands != "End")
            {
                matrix[beeRow, beeCol] = '.';

                beeRow = MoveRow(beeRow, commands);
                beeCol = MoveCol(beeCol, commands);

                if (!IsPositionValid(beeRow, beeCol, size, size))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (matrix[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }
                else if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';

                    beeRow = MoveRow(beeRow, commands);
                    beeCol = MoveCol(beeCol, commands);

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        pollinatedFlowers++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';
                commands = Console.ReadLine();
            }
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
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
