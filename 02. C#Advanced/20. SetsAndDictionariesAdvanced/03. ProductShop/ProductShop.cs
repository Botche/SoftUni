using System;
using System.Collections.Generic;

namespace _03._ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productListWithShops
                = new SortedDictionary<string, Dictionary<string, double>>();

            string[] command = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0].ToLower()!="revision")
            {
                string shopName = command[0];
                string product = command[1];
                double priceOfProduct = double.Parse(command[2]);

                if (!productListWithShops.ContainsKey(shopName))
                {
                    productListWithShops.Add(shopName, new Dictionary<string, double>());
                }

                productListWithShops[shopName].Add(product, priceOfProduct);
                command = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var shop in productListWithShops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
