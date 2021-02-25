using System;
using System.Linq;
using System.Text;

namespace _05._MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine().TrimStart('0');
            int secondNum = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            int temp = 0;

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            foreach (var item in inputNum.Reverse())
            {
                int digit = int.Parse(item.ToString());
                int multiplyNum = digit * secondNum + temp;

                int lastDigit = multiplyNum % 10;
                temp = multiplyNum / 10;

                result.Insert(0, lastDigit);
            }

            if (temp > 0)
            {
                result.Insert(0, temp);
            }

            Console.WriteLine(result);
        }
    }
}
