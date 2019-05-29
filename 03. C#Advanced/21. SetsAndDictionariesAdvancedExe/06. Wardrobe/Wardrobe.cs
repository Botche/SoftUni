using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe
                = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                    }
                    wardrobe[color][cloth]++;
                }
            }
            string[] clothToBeFound = Console.ReadLine()
                .Split();
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (clothToBeFound[0]==color.Key && clothToBeFound[1]==cloth.Key)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
