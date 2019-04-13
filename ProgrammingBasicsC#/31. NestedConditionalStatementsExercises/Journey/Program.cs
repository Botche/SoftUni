using System;

namespace journey
{
    class Program
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double money2;

            if(money<=100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (season == "summer")
                {
                    money2 = money * 0.30;
                    Console.WriteLine($"Camp - {money2:f2}");
                }
                else
                {
                    money2 = money * 0.70;
                    Console.WriteLine($"Hotel - {money2:f2}");
                }
            }
            else if(money>100 && money<=1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    money2 = money * 0.40;
                    Console.WriteLine($"Camp - {money2:f2}");
                }
                else
                {
                    money2 = money * 0.80;
                    Console.WriteLine($"Hotel - {money2:f2}");
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                money2 = money * 0.90;
                Console.WriteLine($"Hotel - {money2:f2}");
            }
        }
    }
}
