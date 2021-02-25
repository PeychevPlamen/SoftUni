using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputType = Console.ReadLine();

            Console.WriteLine(GetMax(inputType));

        }

        private static string GetMax(string inputType)
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            string getMax = string.Empty;

            if (inputType == "int")
            {
                int firstNum = int.Parse(firstInput);
                int secondNum = int.Parse(secondInput);

                if (firstNum >= secondNum)
                {
                    getMax = Convert.ToString(firstNum);
                }
                else if (firstNum <= secondNum)
                {
                    getMax = Convert.ToString(secondNum);
                }

            }
            if (inputType == "char")
            {
                char firstChar = char.Parse(firstInput);
                char secondChar = char.Parse(secondInput);

                if (firstChar >= secondChar)
                {
                    getMax = Convert.ToString(firstChar);
                }
                else if (firstChar <= secondChar)
                {
                    getMax = Convert.ToString(secondChar);
                }

            }
            if (inputType == "string")
            {

                int sumFirstString = 0;
                int sumSecondString = 0;

                for (int i = 0; i < firstInput.Length; i++)
                {
                    sumFirstString += Convert.ToChar(firstInput[i]);
                }
                for (int j = 0; j < secondInput.Length; j++)
                {
                    sumSecondString += Convert.ToChar(secondInput[j]);
                }
                if (sumFirstString >= sumSecondString)
                {
                    getMax = firstInput;
                }
                else if (sumFirstString <= sumSecondString)
                {
                    getMax = secondInput;
                }

            }
            return getMax;
        }
    }
}
