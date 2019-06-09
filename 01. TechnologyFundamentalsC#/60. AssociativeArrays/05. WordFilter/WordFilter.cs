using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine()
                .Split();

            var sorted = products.Where(x => x.Length % 2 == 0).ToArray();
            foreach (var product in sorted)
            {
                Console.WriteLine(product);
            }
        }
    }
}
