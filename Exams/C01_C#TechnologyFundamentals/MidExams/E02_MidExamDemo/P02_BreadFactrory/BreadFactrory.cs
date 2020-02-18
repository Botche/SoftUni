using System;

namespace BreadFactrory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] events = Console.ReadLine().Split("|");
            int energy = 100, coins = 100;
            for (int i = 0; i < events.Length; i++)
            {
                string[] action = events[i].Split("-");
                if (action[0] == "rest")
                {
                    int energyRecover = int.Parse(action[1]);
                    if (energy + energyRecover > 100)
                    {
                        energy = 100;
                        Console.WriteLine($"You gained 0 energy.");
                    }
                    else
                    {
                        Console.WriteLine($"You gained {energyRecover} energy.");
                        energy += energyRecover;
                    }
                    Console.WriteLine($"Current energy: {energy}.");
                }
                else if (action[0] == "order")
                {
                    int moneyIncome = int.Parse(action[1]);
                    if (energy  < 30)
                    {
                        Console.WriteLine("You had to rest!");
                        energy += 50;
                    }
                    else
                    {
                        Console.WriteLine($"You earned {moneyIncome} coins.");
                        coins += moneyIncome;
                        energy -= 30;
                    }
                }
                else
                {
                    int productCosts = int.Parse(action[1]);
                    coins -= productCosts;
                    if (coins <= 0)
                    {
                        Console.WriteLine($"Closed! Cannot afford { action[0]}.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You bought {action[0]}.");
                    }
                }
            }
            if (coins > 0)
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
            }
        }
    }
}
