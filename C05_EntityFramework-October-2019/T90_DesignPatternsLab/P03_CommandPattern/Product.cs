﻿using System;

namespace P03_CommandPattern
{
    public class Product
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(int amount)
        {
            Price += amount;
            Console.WriteLine($"The price for the {Name} has been increase by {amount}$");
        }

        public void DecreasePrice(int amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price for the {Name} decreased by {amount}$");
            }
        }

        public override string ToString() => $"Current price for the {Name} product is {Price}$";

    }
}
