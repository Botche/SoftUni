using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValues
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            Dictionary<double, int> counterOfSameValues = new Dictionary<double, int>();

            foreach (var item in input)
            {
                if (!counterOfSameValues.ContainsKey(item))
                    counterOfSameValues.Add(item, 0);
                counterOfSameValues[item]++;
            }

            foreach (var item in counterOfSameValues)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
