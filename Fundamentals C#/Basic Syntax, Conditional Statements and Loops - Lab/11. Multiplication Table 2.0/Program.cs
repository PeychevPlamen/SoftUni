using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplierNum = int.Parse(Console.ReadLine());

            if (multiplierNum > 10)
            {
                Console.WriteLine($"{n} X {multiplierNum} = {n * multiplierNum}");
            }
            else
            {
                for (int i = multiplierNum; i <= 10; i++)
                {
                    Console.WriteLine($"{n} X {i} = {n * i}");
                }
            }
        }
    }
}
