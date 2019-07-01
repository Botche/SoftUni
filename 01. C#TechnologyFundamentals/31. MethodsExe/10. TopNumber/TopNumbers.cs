using System;

namespace topNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int highRange = int.Parse(Console.ReadLine());

            PrintMastersNumberFromOneToN(highRange);
        }

        private static void PrintMastersNumberFromOneToN(int highRange)
        {
            for (int i = 17; i <= highRange; i++)
            {
                bool oddDigit = false;
                long sum = 0;
                int num = i;
                while (num > 0)
                {
                    sum += num % 10;
                    if ((num % 10) % 2 == 1)
                        oddDigit = true;
                    num /= 10;
                }
                if (sum % 8 == 0 && oddDigit == true)
                    Console.WriteLine(i);
            }
        }
    }
}
