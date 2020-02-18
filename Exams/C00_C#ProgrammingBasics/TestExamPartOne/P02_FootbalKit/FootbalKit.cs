using System;

namespace footbalKit
{
    class Program
    {
        static void Main()
        {
            double priceT = double.Parse(Console.ReadLine());
            double sum = double.Parse(Console.ReadLine());
            double priceS = priceT * 0.75;
            double priceC = priceS * 0.20;
            double priceB = 2 * (priceS + priceT);
            double price = priceT + priceS + priceC + priceB;
            price = price - price * 0.15;
            if (price >= sum)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {price:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {sum - price:f2} lv. more.");
            }
        }
    }
}
