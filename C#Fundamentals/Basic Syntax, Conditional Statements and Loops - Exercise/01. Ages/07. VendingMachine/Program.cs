using System;

namespace _07._VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string money = Console.ReadLine();
            double totalSum = 0;

            while (money != "Start")
            {
                double coin = double.Parse(money);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    totalSum += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                money = Console.ReadLine();
            }

            string product = Console.ReadLine();
            double price = 0;

            while (product != "End")
            {

                switch (product)
                {
                    case "Nuts":
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }
                if (price <= totalSum)
                {
                    totalSum -= price;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalSum:f2}");
        }
    }
}
