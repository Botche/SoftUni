using System;
using System.Linq;

namespace passwordValidator
{
    class Program
    {
        static bool ForLength = false;
        static  bool ForLetters = false;
        static bool ForTwoDigits = false;
        static void Main(string[] args)
        {
            string passwordForValidation = Console.ReadLine().ToLower();
            PasswordValidateForLength(passwordForValidation);
            PasswordValidateForLettersAndDigits(passwordForValidation);
            PasswordValidateForTwoDigits(passwordForValidation);
            if (ForLength == true
                && ForLetters == true
                && ForTwoDigits == true)
                Console.WriteLine("Password is valid");
        }

        static void PasswordValidateForTwoDigits(string passwordForValidation)
        {
            int counter = 0;
            for (int i = 0; i < passwordForValidation.Length; i++)
            {
                if (char.IsDigit(passwordForValidation[i]))
                    counter++;
            }
            if (counter < 2)
                Console.WriteLine("Password must have at least 2 digits");
            else
                ForTwoDigits = true;
        }

        static void PasswordValidateForLettersAndDigits(string passwordForValidation)
        {
            int counter = 0;
            for (int i = 0; i < passwordForValidation.Length; i++)
            {
                if (char.IsLetterOrDigit(passwordForValidation[i]))
                    counter++;
            }
            if (counter == passwordForValidation.Length)
                ForLetters = true;
            else
                Console.WriteLine("Password must consist only of letters and digits");

        }

        static void PasswordValidateForLength(string passwordForValidation)
        {
            if (passwordForValidation.Length > 5 && passwordForValidation.Length <= 10)
                ForLength = true;
            else
                Console.WriteLine("Password must be between 6 and 10 characters");
        }
    }
}
