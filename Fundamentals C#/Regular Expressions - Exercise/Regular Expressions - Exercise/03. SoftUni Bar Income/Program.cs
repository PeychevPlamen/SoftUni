using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d+)\$";

            Regex regex = new Regex(pattern);

            double totalIncome = 0;

            while (input != "end of shift")
            {
                MatchCollection customer = regex.Matches(input);
                double totalPrice = 0;

                foreach (Match tokens in customer)
                {
                    string name = tokens.Groups[1].Value;
                    string product = tokens.Groups[2].Value;
                    int quantity = int.Parse(tokens.Groups[3].Value);
                    double price = double.Parse(tokens.Groups[4].Value);

                    totalPrice = quantity * price;

                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }

                totalIncome += totalPrice;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
