using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string seazon = Console.ReadLine().ToLower();
            double numberF = double.Parse(Console.ReadLine());
            double price = 0;

            if (seazon == "spring")
            {
                price = 3000;
                if (numberF <= 6)
                {

                    price = 3000 - (3000 * 0.10);
                }
                else if (numberF >= 7 && numberF <= 11)
                {

                    price = 3000 - (3000 * 0.15);
                }
                else if (numberF >= 12)
                {

                    price = 3000 - (3000 * 0.25);
                }
                if (numberF % 2 == 0)
                {
                    price = price - (price * 0.05);
                }
            }
            else if (seazon == "summer" || seazon == "autumn")
            {
                price = 4200;
                if (numberF <= 6)
                {

                    price = 4200 - (4200 * 0.10);
                }
                else if (numberF >= 7 && numberF <= 11)
                {

                    price = 4200 - (4200 * 0.15);
                }
                else if (numberF >= 12)
                {

                    price = 4200 - (4200 * 0.25);
                }
                if ((numberF % 2 == 0) && (seazon == "summer"))
                {
                    price = price - (price * 0.05);
                }

            }
            else if (seazon == "winter")
            {
                price = 2600;
                if (numberF <= 6)
                {

                    price = 2600 - (2600 * 0.10);
                }
                else if (numberF >= 7 && numberF <= 11)
                {

                    price = 2600 - (2600 * 0.15);
                }
                else if (numberF >= 12)
                {

                    price = 2600 - (2600 * 0.25);
                }
                if (numberF % 2 == 0)
                {
                    price = price - (price * 0.05);
                }
            }
            if (budget >= price)
            {

                Console.WriteLine($"Yes! You have {budget - price:F2} leva left.");
            }
            else
            {

                Console.WriteLine($"Not enough money! You need {price - budget:F2} leva.");
            }

        }
    }
}