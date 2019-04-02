using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials["fragments"] = 0;
            materials["shards"] = 0;
            materials["motes"] = 0;

            string material = "";
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                bool b = false;
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    material = input[i + 1].ToLower();
                    
                    if (material == "fragments" || material == "motes" || material == "shards")
                    {
                        if (materials.ContainsKey(material))
                        {
                            materials[material] += quantity;
                            if (materials[material] >= 250)
                            {
                                b = true;
                                break;
                            }
                        }
                        else
                        {
                            materials.Add(material, quantity);
                            if (materials[material] >= 250)
                            {
                                b = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                            junk[material] += quantity;
                        else
                            junk.Add(material, quantity);
                    }
                }
                if (b==true)
                {
                    materials[material] -= 250;
                    break;
                }
            }
            if (material == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (material == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }
            else if (material == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            var orderedMaterials = materials.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(a=>a.Key,a=>a.Value);
            foreach (var item in orderedMaterials)
            { 
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var junks in junk)
            {
                Console.WriteLine($"{junks.Key}: {junks.Value}");
            }
        }
    }
}
