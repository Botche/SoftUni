using System;

namespace stadiumIncome
{
    class Program
    {
        static void Main()
        {
            int sec = int.Parse(Console.ReadLine());
            int cap = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            double sum = (cap * ticketPrice) / sec;
            double charity = 0.125 * (cap * ticketPrice - (0.75 * sum));
            Console.WriteLine($"Total income - {cap * ticketPrice:f2} BGN");
            Console.WriteLine($"Money for charity - {charity:f2} BGN");
            
        }
    }
}
