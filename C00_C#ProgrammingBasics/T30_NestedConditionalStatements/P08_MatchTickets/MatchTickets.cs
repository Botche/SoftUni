using System;

namespace matchTickets
{
    class Program
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            string ticket = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            double sum;
            if      (b >= 1 && b <= 4)
                money = money - money * 0.75;
            else if (b >= 5 && b < 10)
                money = money - money * 0.60;
            else if (b >= 10 && b < 25)
                money = money - money * 0.50;
            else if (b >= 25 && b < 50)
                money = money - money * 0.40;
            else if (b >= 50)
                money = money - money * 0.25;
            
            if (ticket == "Normal")
            {
                sum = 249.99 * b;
                if (money >= sum)
                    Console.WriteLine($"Yes! You have {money-sum:f2} leva left.");
                else
                    Console.WriteLine($"Not enough money! You need {sum - money:f2} leva.");
            }
            else if(ticket=="VIP")
            {
                sum = 499.99*b;
                if (money >= sum)
                    Console.WriteLine($"Yes! You have {money - sum:f2} leva left.");
                else
                    Console.WriteLine($"Not enough money! You need {sum - money:f2} leva.");
            }
            Console.ReadKey();
        }
    }
}
