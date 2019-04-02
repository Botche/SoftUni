using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] productInfo = Console.ReadLine().Split();
            Dictionary<string, ProductInfo> products = new Dictionary<string, ProductInfo>();
            while (productInfo[0] != "buy")
            {
                string productName = productInfo[0];
                double price = double.Parse(productInfo[1]);
                int quantity = int.Parse(productInfo[2]);

                if (!products.ContainsKey(productName))
                {
                    products.Add(productName, new ProductInfo());
                }
                products[productName].Quantity += quantity;
                products[productName].Price = price;

                productInfo = Console.ReadLine().Split();
            }
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Quantity*product.Value.Price:f2}");
            }
        }

    }

    class ProductInfo
    {
        public double Price;
        public int Quantity;
    }
}
