using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double totalPrice = 0;

            if (groupType == "Students")
            {
                if (day == "Friday")
                {
                    totalPrice = 8.45 * people;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 9.80 * people;
                }
                else if (day == "Sunday")
                {
                    totalPrice = 10.46 * people;
                }
                if (people >= 30)
                {
                    totalPrice = totalPrice * 0.85;
                }
            }
            else if (groupType == "Business")
            {
                if (day == "Friday")
                {
                    totalPrice = 10.90 * people;

                    if (people >= 100)
                    {
                        totalPrice -= 10.90 * 10;
                    }
                }
                else if (day == "Saturday")
                {
                    totalPrice = 15.60 * people;

                    if (people >= 100)
                    {
                        totalPrice -= 15.60 * 10;
                    }
                }
                else if (day == "Sunday")
                {
                    totalPrice = 16 * people;

                    if (people >= 100)
                    {
                        totalPrice -= 16 * 10;
                    }
                }
            }
            else if (groupType == "Regular")
            {
                if (day == "Friday")
                {
                    totalPrice = 15 * people;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 20 * people;
                }
                else if (day == "Sunday")
                {
                    totalPrice = 22.50 * people;
                }
                if (people >= 10 && people <= 20)
                {
                    totalPrice = totalPrice * 0.95;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
