using System;
using System.Collections.Generic;
using System.Linq;

namespace OnTheWayToAnnapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split("->");

            while (input[0]!="END")
            {
                string command = input[0];
                string nameStore = input[1];

                if (command == "Add")
                { 
                    string[] items = input[2].Split(",");
                    if (!stores.ContainsKey(nameStore))
                    {
                        stores.Add(nameStore, new List<string>());
                    }
                    foreach (var item in items)
                    {
                        stores[nameStore].Add(item);
                    }
                }
                else
                {
                    if (stores.ContainsKey(nameStore))
                        stores.Remove(nameStore);
                }
                input = Console.ReadLine().Split("->");
            }

            Console.WriteLine("Stores list:");
            foreach (var store in stores.OrderByDescending(x=>x.Value.Count).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine(store.Key);
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
