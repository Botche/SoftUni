using System;

namespace fanShop
{
    class Program
    {
        static void Main()
        {
            int money = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string predmet = "";
            int sum = 0;
            for(var i=0;i<n;i++)
            {
                predmet = Console.ReadLine();
                if (predmet == "hoodie")
                    sum += 30;
                else if (predmet == "keychain")
                    sum += 4;
                else if (predmet == "T-shirt")
                    sum += 20;
                else if (predmet == "flag")
                    sum += 15;
                else
                    sum += 1;
            }
            if(sum<=money)
                Console.WriteLine($"You bought {n} items and left with {money-sum} lv.");
            else
                Console.WriteLine($"Not enough money, you need {sum-money} more lv.");   
        }
    }
}
