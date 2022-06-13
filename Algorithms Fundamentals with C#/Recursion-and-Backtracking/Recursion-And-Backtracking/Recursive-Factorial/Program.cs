using System;

namespace Recursive_Factorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcRecursiveFact(n));
        }

        private static int CalcRecursiveFact(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * CalcRecursiveFact(n - 1);
        }
    }
}
