using System;
using System.Collections.Generic;
using System.Linq;

namespace VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(", ");

            Dictionary<string, double> prices = new Dictionary<string, double>();
            Dictionary<string, string> dlcs = new Dictionary<string, string>();

            foreach (var input in inputs)
            {
                if (input.Contains('-'))
                {
                    string[] info = input.Split("-");
                    string game = info[0];
                    double price = double.Parse(info[1]);

                    if (!prices.ContainsKey(game))
                    {
                        prices.Add(game, price);
                    }
                    else
                        prices[game] = price;

                }
                else if (input.Contains(':'))
                {
                    string[] info = input.Split(":");
                    string game = info[0];
                    string dlc = info[1];

                    if(prices.ContainsKey(game))
                    {
                        dlcs.Add(game, dlc);
                        prices[game] += prices[game] * 0.2;
                    }


                }
            }
            foreach (var game in prices.OrderBy(x=>x.Value))
            {
                if (dlcs.ContainsKey(game.Key))
                {
                    Console.WriteLine($"{game.Key} - {dlcs[game.Key]} - {game.Value*0.5:f2}");
                }
            }
            foreach (var game in prices.OrderByDescending(x => x.Value))
            {
                if (!dlcs.ContainsKey(game.Key))
                {
                    Console.WriteLine($"{game.Key} - {game.Value*0.8:f2}");
                }
            }
        }
    }
}
