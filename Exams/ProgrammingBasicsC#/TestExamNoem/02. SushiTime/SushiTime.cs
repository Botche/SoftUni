using System;
namespace sushiTime
{
    class Program
    {
        static void Main()
        {
            string sushi = Console.ReadLine();
            string res = Console.ReadLine();
            int dishes = int.Parse(Console.ReadLine());
            string sym = Console.ReadLine();
            double sum = 0,boll=0;
            if (res == "Sushi Zone")
            {
                boll= 0;
                if (sushi == "sashimi")
                    sum += 4.99;
                else if (sushi == "maki")
                    sum += 5.29;
                else if (sushi == "uramaki")
                    sum += 5.99;
                else
                    sum += 4.29;
            }
            else if (res == "Sushi Time")
            {
                boll = 0;
                if (sushi == "sashimi")
                    sum += 5.49;
                else if (sushi == "maki")
                    sum += 4.69;
                else if (sushi == "uramaki")
                    sum += 4.49;
                else
                    sum += 5.19;
            }
            else if (res == "Sushi Bar")
            {
                boll = 0;
                if (sushi == "sashimi")
                    sum += 5.25;
                else if (sushi == "maki")
                    sum += 5.55;
                else if (sushi == "uramaki")
                    sum += 6.25;
                else
                    sum += 4.75;
            }
            else if (res == "Asian Pub")
            {
                boll = 0;
                if (sushi == "sashimi")
                    sum += 4.50;
                else if (sushi == "maki")
                    sum += 4.80;
                else if (sushi == "uramaki")
                    sum += 5.50;
                else
                    sum += 5.50;
            }
            else
            {
                boll = 1;
                Console.WriteLine($"{res} is invalid restaurant!");
            }
            if(boll==0)
            {
                if (sym == "Y")
                {
                    sum = (sum+sum * 0.20)*dishes;
                    Console.WriteLine($"Total price: {Math.Ceiling(sum)} lv.");
                }
                else
                {
                    sum *= dishes;
                    Console.WriteLine($"Total price: {Math.Ceiling(sum)} lv.");
                }
            }
            
        }
    }
}
