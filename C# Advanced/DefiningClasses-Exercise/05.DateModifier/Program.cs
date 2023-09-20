using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.GetDiffBetweenDatesInDays(firstDate, secondDate);

            Console.WriteLine(Math.Abs(days));
        }
    }
}
