using System;

namespace sighOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SighOfNumber(number);
        }

        private static void SighOfNumber(int number)
        {
            if (number < 0)
                Console.WriteLine($"The number {number} is negative.");
            else if (number == 0)
                Console.WriteLine($"The number {number} is zero.");
            else
            {
                Console.WriteLine($"The number {number} is possitive.");
            }
        }
    }
}
