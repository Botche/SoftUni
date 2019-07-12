using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] shoppers = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsAndPrices = Console.ReadLine().Split(new char[] { ';', '=' },StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            for (int i = 0; i < shoppers.Length; i += 2)
            {
                Person person = new Person();
                person.Name = shoppers[i];
                person.Money = double.Parse(shoppers[i + 1]);
                person.BagOfProducts = new List<Product>();
                people.Add(person);
            }

            List<Product> products = new List<Product>();
            for (int i = 0; i < productsAndPrices.Length; i += 2)
            {
                Product product = new Product();
                product.Name = productsAndPrices[i];
                product.Cost = double.Parse(productsAndPrices[i + 1]);

                products.Add(product);
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                string name = input[0];
                string prod = input[1];
                var shopper = people.Find(x => x.Name == name);
                var prodFromList = products.Find(x => x.Name == prod);

                if (prodFromList.Cost <= shopper.Money)
                { 
                    shopper.BagOfProducts.Add(prodFromList);
                    shopper.Money -= prodFromList.Cost;
                    Console.WriteLine($"{name} bought {prod}");
                }
                else
                {
                    Console.WriteLine($"{name} can't afford {prod}");
                }
                input = Console.ReadLine().Split();
            }
            foreach (var person in people)
            {
                Console.Write(person.Name + " - ");
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    for (int i = 0; i < person.BagOfProducts.Count; i++)
                    {
                        if(i==person.BagOfProducts.Count-1)
                            Console.Write(person.BagOfProducts[i].Name);
                        else
                            Console.Write(person.BagOfProducts[i].Name+", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Person
    {
        public string Name;
        public double Money;
        public List<Product> BagOfProducts;
    }

    class Product
    {
        public string Name;
        public double Cost;
    }
}
