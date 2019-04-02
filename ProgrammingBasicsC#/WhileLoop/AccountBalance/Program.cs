using System;

namespace accountBalance
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int count = 1;
            double sum = 0;

            while (count <= n)
            {
                double amount = double.Parse(Console.ReadLine());
                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    sum += amount;
                    Console.WriteLine($"Increase: {amount:f2}");
                }
                count++;
            }
            Console.WriteLine($"Total: {sum:f2}");
            Console.ReadKey();
        }
    }
}
