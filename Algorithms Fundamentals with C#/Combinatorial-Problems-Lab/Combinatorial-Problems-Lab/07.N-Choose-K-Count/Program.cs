using System;

namespace _07.N_Choose_K_Count
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(n, k));
        }

        private static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || row == col)
            {
                return 1;
            }

            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
        }
    }
}
