using System;
using System.Linq;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urlInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in phoneInput)
            {
                if (item.Any(char.IsLetter))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (item.Length == 7)
                {
                    StationaryPhone phone = new StationaryPhone();

                    Console.WriteLine(phone.Call(item));
                }
                else if (item.Length == 10)
                {
                    Smartphone phone = new Smartphone();

                    Console.WriteLine(phone.Call(item));
                }
                               
            }

            foreach (var url in urlInput)
            {
                if (url.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Smartphone phone = new Smartphone();

                    Console.WriteLine(phone.Browse(url));
                }
            }
        }
    }
}
