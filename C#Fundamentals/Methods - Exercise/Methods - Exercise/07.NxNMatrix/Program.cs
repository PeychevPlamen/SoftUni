using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            NumberMatrix(input);
        }

        private static void NumberMatrix(int input)
        {
            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    Console.Write($"{input} ");
                }

                Console.WriteLine();
            }
        }
    }
}
