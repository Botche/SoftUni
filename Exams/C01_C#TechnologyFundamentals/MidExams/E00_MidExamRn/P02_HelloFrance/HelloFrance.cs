using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] collectionOfItems = Console.ReadLine().Split("|");
            double budget = double.Parse(Console.ReadLine());

            double maxPriceC = 50.0;
            double maxPriceS = 35.0;
            double maxPriceA = 20.5;
            double oldSum = 0;
            List<double> items = new List<double>();
            foreach (var itemInCol in collectionOfItems)
            {
                string[] item = itemInCol.Split("->").ToArray();
                double itemPr = double.Parse(item[1]);
                string itemName = item[0];

                switch (itemName)
                {
                    case "Clothes":
                        if (itemPr <= maxPriceC)
                        {
                            if (budget - itemPr >= 0)
                            {
                                oldSum += itemPr;
                                budget -= itemPr;
                                itemPr += itemPr * 0.4;
                                items.Add(itemPr);
                            }
                        }
                        break;

                    case "Shoes":
                        if (itemPr <= maxPriceS)
                        {
                            if (budget - itemPr >= 0)
                            {
                                oldSum += itemPr;
                                budget -= itemPr;
                                itemPr += itemPr * 0.4;
                                items.Add(itemPr);
                            }
                        }
                        break;

                    case "Accessories":
                        if (itemPr <= maxPriceA)
                        {
                            if (budget - itemPr >= 0)
                            {
                                oldSum += itemPr;
                                budget -= itemPr;
                                itemPr += itemPr * 0.4;
                                items.Add(itemPr);
                            }
                        }
                        break;
                }
            }
            double newSum = 0;
            for (int i = 0; i < items.Count; i++)
            {
                newSum += items[i];
                if (i == items.Count - 1)
                {
                    Console.Write($"{items[i]:f2}");

                }
                else
                    Console.Write($"{items[i]:f2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {newSum - oldSum:f2}");
            newSum += budget;
            if (newSum > 150)
                Console.WriteLine("Hello, France!");
            else
                Console.WriteLine("Time to go.");
        }
    }
}
