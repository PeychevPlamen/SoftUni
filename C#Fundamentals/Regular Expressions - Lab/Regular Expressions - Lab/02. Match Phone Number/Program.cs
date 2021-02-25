using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[+][359]+([ \-])([2]\1)+(\d{3}\1)+(\d{4})\b";

            var phones = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matchPhones = regex.Matches(phones);

            Console.WriteLine(string.Join(", ", matchPhones));
        }
    }
}
