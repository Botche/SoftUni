using System;

namespace footballSouvenirs
{
    class Program
    {
        static void Main()
        {
            string team = Console.ReadLine();
            string souvenir = Console.ReadLine();
            double n = double.Parse(Console.ReadLine());
            double sum = 0;
            string team1 = "1";
            if(team=="Argentina")
            {
                team1 = "Argentina";
                if (souvenir == "flags")
                    sum = n * 3.25;
                else if (souvenir == "caps")
                    sum = n * 7.20;
                else if (souvenir == "posters")
                    sum = n * 5.10;
                else if (souvenir == "stickers")
                    sum = n * 1.25;
                else
                    Console.WriteLine("Invalid stock!");
            }
            else if(team=="Brazil")
            {
                team1 = "Brazil";
                if (souvenir == "flags")
                    sum = n * 4.20;
                else if (souvenir == "caps")
                    sum = n * 8.50;
                else if (souvenir == "posters")
                    sum = n * 5.35;
                else if (souvenir == "stickers")
                    sum = n * 1.20;
                else
                    Console.WriteLine("Invalid stock!");
            }
            else if (team == "Croatia")
            {
                team1 = "Croatia";
                if (souvenir == "flags")
                    sum = n * 2.75;
                else if (souvenir == "caps")
                    sum = n * 6.90;
                else if (souvenir == "posters")
                    sum = n * 4.95;
                else if(souvenir == "stickers")
                    sum = n * 1.10;
                else
                    Console.WriteLine("Invalid stock!");
            }
            else if(team=="Denmark")
            {
                team1 = "Denmark";
                if (souvenir == "flags")
                    sum = n * 3.10;
                else if (souvenir == "caps")
                    sum = n * 6.50;
                else if (souvenir == "posters")
                    sum = n * 4.80;
                else if(souvenir=="stickers")
                    sum = n * 0.90;
                else
                    Console.WriteLine("Invalid stock!");
            }
            else
                Console.WriteLine("Invalid country!");
            if (team1 == "1 " || sum == 0)
                team1 = "2";
            else
                Console.WriteLine($"Pepi bought {n} {souvenir} of {team} for {sum:f2} lv.");
        }
    }
}
