using System;
using System.Numerics;

namespace _04._CenturiesТoMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;
            decimal days = (decimal)(Math.Round(years * 365.2422));
            decimal hours = days * 24;
            decimal minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} " +
                $"days = {hours} hours = {minutes} minutes");
        }
    }
}
