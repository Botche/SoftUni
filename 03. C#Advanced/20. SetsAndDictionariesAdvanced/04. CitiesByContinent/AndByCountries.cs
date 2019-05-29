using System;
using System.Collections.Generic;

namespace _04._CitiesByContinent
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string,List< string>>> citiesByContinentAndCountry =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string continent = input[0];
                string county = input[1];
                string city = input[2];

                if (!citiesByContinentAndCountry.ContainsKey(continent))
                {
                    citiesByContinentAndCountry.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!citiesByContinentAndCountry[continent].ContainsKey(county))
                {
                    citiesByContinentAndCountry[continent].Add(county, new List<string>());
                }
                citiesByContinentAndCountry[continent][county].Add(city);
            }
            foreach (var continent in citiesByContinentAndCountry)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var county in continent.Value)
                {
                    Console.WriteLine($"    {county.Key} -> {string.Join(", ",county.Value)}");
                }
            }
        }
    }
}
