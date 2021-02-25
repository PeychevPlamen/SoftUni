using System;

namespace _09._PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightSabrePrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double totalLightSabresPrice = (Math.Ceiling(students * 1.1)) * lightSabrePrice;
            double totalRobePrice = (students * robePrice);
            double totalBeltPrice = (students * beltPrice);

            for (int i = 1; i <= students; i++)
            {
                if (i % 6 == 0)
                {
                    totalBeltPrice -= beltPrice;
                }
            }
            
            double totalPrice = totalLightSabresPrice + totalRobePrice + totalBeltPrice;

            if (totalPrice <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - money):f2}lv more.");
            }
        }
    }
}
