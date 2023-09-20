using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char toLookFor = char.Parse(Console.ReadLine());

            int currRow = 0;
            int currCol = 0;
            bool isFind = false;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                if (isFind)
                {
                    break;
                }
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r,c] == toLookFor)
                    {
                        currRow = r;
                        currCol = c;
                        isFind = true;
                        break;
                    }
                }
            }

            if (isFind)
            {
                Console.WriteLine($"({currRow}, {currCol})");
            }
            else
            {
                Console.WriteLine($"{toLookFor} does not occur in the matrix ");
            }
        }
    }
}
