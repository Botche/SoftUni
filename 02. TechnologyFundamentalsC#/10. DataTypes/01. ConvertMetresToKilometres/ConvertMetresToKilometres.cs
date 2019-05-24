using System;

namespace convertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double kmeters = 0;
            kmeters = meters / 1000 + (meters % 1000) * 0.001;
            Console.WriteLine($"{kmeters:f2}");
        }
    }
}
