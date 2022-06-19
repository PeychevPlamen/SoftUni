using System;

namespace _05.Combinations_without_Repetition
{
    public class Program
    {
        private static string[] elements;
        private static string[] combinations;

        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            Combination(0, 0);
        }

        private static void Combination(int index, int elementStartIdx)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIdx; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combination(index + 1, i + 1);
            }
        }
    }
}
