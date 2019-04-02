using System;

namespace newHouse
{
    class Program
    {
        static void Main()
        {
            string flower = Console.ReadLine();
            int br = int.Parse(Console.ReadLine());
            int money = int.Parse(Console.ReadLine());
            double sum=1;
            if(flower=="Roses")
            {
                sum = br * 5;
                if(br > 80)
                sum = sum - sum * 0.10;
            }
            if (flower == "Dahlias")
            {
                sum = br * 3.80;
                if (br > 90)
                    sum = sum - sum * 0.15;
            }
            if (flower == "Tulips")
            {
                sum = br * 2.80;
                if (br > 80)
                    sum = sum - sum * 0.15;
            }
            if (flower == "Narcissus")
            {
                sum = br * 3;
                if (br < 120)
                    sum = sum + sum * 0.15;
            }
            if (flower == "Gladiolus")
            {
                sum = br * 2.50;
                if (br < 80)
                    sum = sum + sum * 0.20;
            }
            if (sum <= money)
                Console.WriteLine($"Hey, you have a great garden with {br} {flower} and {money - sum:f2} leva left.");
            else
                Console.WriteLine($"Not enough money, you need {sum - money:f2} leva more.");
            
        }
    }
}
