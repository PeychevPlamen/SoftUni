using System;

namespace _09._Greater_of_Two_Values_100points
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputType = Console.ReadLine();

            if (inputType == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                Console.WriteLine(GetBigger(first, second));
            }
            if (inputType == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                Console.WriteLine(GetBigger(first, second));
            }
            if (inputType == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                Console.WriteLine(GetBigger(first, second));
            }
        }
        static int GetBigger(int first, int second)
        {
            int compare = first.CompareTo(second);

            if (compare > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
        static char GetBigger(char first, char second)
        {
            int compare = first.CompareTo(second);

            if (compare > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static string GetBigger(string first, string second)
        {
            int compare = first.CompareTo(second);

            if (compare > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
