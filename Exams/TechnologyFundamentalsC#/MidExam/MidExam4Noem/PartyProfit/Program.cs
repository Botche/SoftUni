using System;

namespace PartyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int partyDays = int.Parse(Console.ReadLine());
            int allCoins = partyDays*50;
            for (int i = 1; i <= partyDays; i++)
            {
                
                if (i % 10 == 0)
                {
                    partySize -= 2;
                }
                if (i % 15 == 0)
                {
                    partySize += 5;
                }
                if (i % 3 == 0)
                {
                    allCoins -= 3 * partySize;
                }
                
                if (i % 5 == 0)
                {
                    if (i % 3 == 0)
                    {
                        allCoins -= partySize * 2;
                    }
                }
                allCoins -= 2 * partySize;
            }

            Console.WriteLine($"{partySize} companions received {allCoins / partySize} coins each.");
        }
    }
}
