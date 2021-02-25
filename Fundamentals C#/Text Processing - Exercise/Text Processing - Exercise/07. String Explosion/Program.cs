using System;
using System.Text;
using System.Linq;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            int bombPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];

                if (currChar == '>')
                {
                    bombPower += int.Parse(input[i + 1].ToString());
                    continue;
                }
                if (bombPower > 0)
                {
                    input = input.Remove(i, 1);
                    i--;
                    bombPower--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
