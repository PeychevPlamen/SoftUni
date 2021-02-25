using System;

namespace _05._PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstIndex = int.Parse(Console.ReadLine());
            int secondIndex = int.Parse(Console.ReadLine());

            for (int i = firstIndex; i <= secondIndex; i++)
            {
                char output = (char)i;
                Console.Write($"{output} ");
            }
        }
    }
}
