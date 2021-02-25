using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            IsTopNumber(input);
        }

        private static void IsTopNumber(int input)
        {
            for (int i = 0; i <= input; i++)
            {
                string currentNumber = i.ToString();
                int sumOfDigits = 0;
                bool isOddNum = false;

                foreach (var curr in currentNumber)
                {
                    int parseNum = curr;

                    if (parseNum % 2 == 1)
                    {
                        isOddNum = true;
                    }

                    sumOfDigits += parseNum;
                }

                if (sumOfDigits % 8 == 0 && isOddNum)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
