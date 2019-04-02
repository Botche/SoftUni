using System;

namespace threeBrothers
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double sum;
            sum = 1 / (1 / a + 1 / b + 1 / c);
            sum = sum + sum * 0.15;
            Console.WriteLine($"Cleaning time: {sum:f2}");
            if(sum<d)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(d - sum)} hours.");
            }
            else
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(sum - d)} hours.");
            Console.ReadKey();
        }
    }
}
