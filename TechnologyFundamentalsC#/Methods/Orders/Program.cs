using System;

namespace orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int quanityOfProduct = int.Parse(Console.ReadLine());

            SumThePriceOfOrder(order, quanityOfProduct);
        }

        private static void SumThePriceOfOrder(string order, int quanityOfProduct)
        {
            double sum = 0;
            if (order == "coffee")
            {
                sum = 1.50 * quanityOfProduct;
                Console.WriteLine($"{sum:f2}");
            }
            else if (order == "water")
            {
                sum = 1.00 * quanityOfProduct;
                Console.WriteLine($"{sum:f2}");
            }
            else if (order == "coke")
            {
                sum = 1.40 * quanityOfProduct;
                Console.WriteLine($"{sum:f2}");
            }
            else if (order == "snacks")
            {
                sum = 2.00 * quanityOfProduct;
                Console.WriteLine($"{sum:f2}");
            }
        }
    }
}
