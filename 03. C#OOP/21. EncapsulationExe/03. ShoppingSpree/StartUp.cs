using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] peopleInput = Console.ReadLine()
                    .Split(";");

                var people = new List<Person>();
                FillPeople(peopleInput, people);

                string[] productsInput = Console.ReadLine()
                    .Split(";");

                var products = new List<Product>();
                FillProducts(productsInput, products);

                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    var tokens = command
                        .Split(" ");

                    var clientName = tokens[0];
                    var productToBuy = tokens[1];

                    var client = people.FirstOrDefault(p => p.Name == clientName);
                    var product = products.FirstOrDefault(p => p.Name == productToBuy);

                    client.AddProduct(product);
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FillProducts(string[] productsInput, List<Product> products)
        {
            foreach (var product in productsInput)
            {
                var productInfo = product
                    .Split("=");

                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                var productToAdd = new Product(name, cost);

                products.Add(productToAdd);
            }
        }

        private static void FillPeople(string[] peopleInput, List<Person> people)
        {
            foreach (var client in peopleInput)
            {
                string[] personTokens = client
                    .Split("=");

                string name = personTokens[0];
                decimal money = decimal.Parse(personTokens[1]);

                var person = new Person(name, money);

                people.Add(person);
            }
        }
    }
}
