using System;

namespace Recursive_Drawing
{
    public class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            PrintFigure(number);

        }

        private static void PrintFigure(int n)
        {
            if (n == 0)
            {
                return;
            }


            Console.WriteLine(new string('*', n));

            PrintFigure(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
