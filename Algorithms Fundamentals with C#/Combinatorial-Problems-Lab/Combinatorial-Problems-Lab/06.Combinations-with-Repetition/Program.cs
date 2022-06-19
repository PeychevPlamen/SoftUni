using System;

namespace _06.Combinations_with_Repetition
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

            CombinationWithRep(0, 0);
        }

        private static void CombinationWithRep(int index, int elementStartIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIndex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                CombinationWithRep(index + 1, i);
            }
        }
    }
}
