using System;

namespace palindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                int num = int.Parse(command);
                Console.WriteLine(CheckIfPalindrom(num));
                command = Console.ReadLine();
            }

        }

        private static string CheckIfPalindrom(int num)
        {
            int counter = 0;
            bool b = false;
            int[] arr = new int[100000];
            while (num > 0)
            {
                arr[counter] = num % 10;
                counter++;
                num /= 10;
            }
            for (int i = 0; i < counter - i; i++)
            {
                if (arr[i] == arr[counter - i - 1])
                    b = true;
                else
                {
                    b = false;
                    break;
                }

            }
            if (b == true)
                return "true";
            else
                return "false";
        }
    }
}
