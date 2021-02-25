using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int divisonNum = 0;

            if (num % 2 == 0)
            {
                divisonNum = 2;

                if (num % 6 == 0)
                {
                    divisonNum = 6;
                }
                if (num % 10 == 0)
                {
                    divisonNum = 10;
                }
                Console.WriteLine($"The number is divisible by {divisonNum}");
                
            }
            else if (num % 3 == 0)
            {
                divisonNum = 3;

                if (num % 7 == 0)
                {
                    divisonNum = 7;
                }
                Console.WriteLine($"The number is divisible by {divisonNum}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
