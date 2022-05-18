using System;
using System.Text;

namespace Generating_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var arr = new int[num];

            Generate(arr, 0);
        }

        private static void Generate(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));

                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                Generate(arr, index + 1);
            }

        }
    }
}
