using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                char[] reversed = input.ToCharArray();
                Array.Reverse(reversed);
                string output = new string(reversed);

                Console.WriteLine($"{input} = {output}");

                input = Console.ReadLine();
            }
        }
    }
}
