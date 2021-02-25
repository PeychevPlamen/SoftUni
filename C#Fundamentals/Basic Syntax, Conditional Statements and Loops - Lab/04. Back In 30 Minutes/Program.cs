using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int extraMinutes = minutes + 30;
            int currentHour = 0;
            int currentMinutes = 0;

            if (extraMinutes > 59)
            {
                currentHour = hours + 1;
                currentMinutes = extraMinutes - 60;

                if (currentHour > 23)
                {
                    currentHour -= 24;
                }
            }
            else
            {
                currentMinutes = extraMinutes;
                currentHour = hours;
            }

            if (currentMinutes < 10)
            {
                Console.WriteLine($"{currentHour}:0{currentMinutes}");
            }
            else
            {
                Console.WriteLine($"{currentHour}:{currentMinutes}");
            }
            
        }
    }
}
