using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool passwordLenght = CheckPasswordLenght(password);
            bool lettersOrDigits = CheckForLettersAndDigits(password);
            bool atLeastTwoDigits = CheckForTwoDigitsAtLeast(password);

            if (passwordLenght && lettersOrDigits && atLeastTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
            if (!passwordLenght)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!lettersOrDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!atLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        private static bool CheckForTwoDigitsAtLeast(string password)
        {
            int counter = 0;

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    counter++;

                }
            }
            if (counter >= 2)
            {
                return true;
            }
            return false;
        }

        private static bool CheckForLettersAndDigits(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }

            }
            return true;
        }

        private static bool CheckPasswordLenght(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            return false;

        }
    }
}
