using System;

namespace messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = ""; int sumChar = 0;
            int countLetters = int.Parse(Console.ReadLine());
            int i = 0;
            for (i = 0; i < countLetters; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int oldNumber = number;
                int lastDigit = number % 10, count = 0;
                while (number != 0)
                {
                    number /= 10;
                    count++;
                }
                if (lastDigit == 8 || lastDigit == 9)
                    sumChar = 97 + ((lastDigit - 2) * 3) + count;
                else if (oldNumber == 0)
                    sumChar = 32;
                else if (lastDigit == 1)
                    continue;
                else
                    sumChar = 97 + ((lastDigit - 2) * 3 + count - 1);
                str += (char)sumChar;
            }
            Console.WriteLine(str);
        }
    }
}
