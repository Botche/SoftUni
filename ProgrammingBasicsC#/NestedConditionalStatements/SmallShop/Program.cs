using System;

namespace smallShop
{
    class Program
    {
        static void Main()
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double br = double.Parse(Console.ReadLine());
            if (town == "Sofia")
            {
                if (product == "coffee")
                    Console.WriteLine(0.50 * br);
                if (product == "water")
                    Console.WriteLine(0.80 * br);
                if (product == "beer")
                    Console.WriteLine(1.20 * br);
                if (product == "sweets")
                    Console.WriteLine(1.45 * br);
                if (product == "peanuts")
                    Console.WriteLine(1.60 * br);
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                    Console.WriteLine(0.40 * br);
                if (product == "water")
                    Console.WriteLine(0.70 * br);
                if (product == "beer")
                    Console.WriteLine(1.15 * br);
                if (product == "sweets")
                    Console.WriteLine(1.30 * br);
                if (product == "peanuts")
                    Console.WriteLine(1.50 * br);
            }
            else
            {
                if (product == "coffee")
                    Console.WriteLine(0.45 * br);
                if (product == "water")
                    Console.WriteLine(0.70 * br);
                if (product == "beer")
                    Console.WriteLine(1.10 * br);
                if (product == "sweets")
                    Console.WriteLine(1.35 * br);
                if (product == "peanuts")
                    Console.WriteLine(1.55 * br);
            }
        }
    }
}
