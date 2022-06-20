using System;
using System.Linq;

namespace _01.Reverse_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().ToArray();

            Reverse(elements, 0);

            Console.WriteLine(string.Join(" ", elements));
        }

        private static void Reverse(string[] elements, int index)
        {
            if (index == elements.Length / 2)
            {
                return;
            }

            var temp = elements[index];
            elements[index] = elements[elements.Length - index - 1];
            elements[elements.Length - index - 1] = temp;

            Reverse(elements, index + 1);
        }
    }
}
