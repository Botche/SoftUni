using System;
using System.Collections.Generic;
using System.Linq;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string resourse = Console.ReadLine();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (resourse != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (dict.ContainsKey(resourse))
                    dict[resourse] += quantity;
                else
                    dict.Add(resourse, quantity);

                resourse = Console.ReadLine();
            }

            foreach (var res in dict)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }
    }
}
