using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascal = new long[n][];
            int cols = 1;

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[cols];
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < pascal[row].Length - 1; col++)
                    {
                        long[] prevRow = pascal[row - 1];
                        long firstNum = prevRow[col - 1];
                        long secondNum = prevRow[col];
                        pascal[row][col] = firstNum + secondNum;
                    }
                }

                cols++;
            }

            foreach (var item in pascal)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
