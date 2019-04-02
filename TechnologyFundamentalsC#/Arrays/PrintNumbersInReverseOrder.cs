using System;

namespace printNumberInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int brDigits = int.Parse(Console.ReadLine());
            int[] numbers = new int[brDigits];
            for (int i = 0; i < brDigits; i++)
                numbers[i] = int.Parse(Console.ReadLine());
            for (int i = brDigits-1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
