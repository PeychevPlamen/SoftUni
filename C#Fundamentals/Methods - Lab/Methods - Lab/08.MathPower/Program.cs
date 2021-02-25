using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int powerNum = int.Parse(Console.ReadLine());

            RaiseToPower(num, powerNum);
        }

        private static double RaiseToPower(double num, int powerNum)
        {
            double result = Math.Pow(num, powerNum);

            Console.WriteLine(result);

            return result;
        }
    }
}
