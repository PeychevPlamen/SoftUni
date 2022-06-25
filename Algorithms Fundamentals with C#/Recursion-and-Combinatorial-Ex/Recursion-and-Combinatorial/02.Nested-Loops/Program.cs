using System;

namespace _02.Nested_Loops
{
    public class Program
    {
        private static int[] elements;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            elements = new int[n];

            GenVectors(0);
        }

        private static void GenVectors(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[index] = i;
                GenVectors(index + 1);
            }
        }
    }
}
