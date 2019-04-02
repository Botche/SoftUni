using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> products = new List<string>(length);
            for (int i = 0; i < length; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }
            products.Sort();
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }
    }
}
