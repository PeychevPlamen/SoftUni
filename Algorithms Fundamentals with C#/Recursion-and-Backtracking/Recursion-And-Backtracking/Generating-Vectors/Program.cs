using System;
using System.Text;

namespace Generating_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var vector = new int[num];

            Generate(vector, 0);
        }

        private static void Generate(int[] vector, int n)
        {
            if (n == vector.Length)
            {
                var sb = new StringBuilder();

                for (int i = 0; i < vector.Length; i++)
                {
                    sb.Append(vector[i]);
                }

                Console.WriteLine(sb.ToString());

                return;
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[n] = i;
                    Generate(vector, n + 1);
                }
            }
        }
    }
}
