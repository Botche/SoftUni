using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value == null || value == "" || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money
        {
            get => money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }
        public List<string> BagOfProducts { get; }

        public void AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                Money -= product.Cost;
                BagOfProducts.Add(product.Name);
            }
        }

        public override string ToString()
        {
            if (BagOfProducts.Count != 0)
            {
                return $"{Name} - {string.Join(", ", BagOfProducts)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }
}
