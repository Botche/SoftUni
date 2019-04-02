using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string Location = Console.ReadLine();
            int Nights = int.Parse(Console.ReadLine());

            double studio = 0;
            double apartament = 0;

            if (Location == "May" || Location == "October")
            {
                studio = 50;
                apartament = 65;

                if (Nights > 7)
                {
                    studio = 50 - (50 * 0.05);
                    apartament = 65;
                }
                if (Nights > 14)
                {
                    studio = 50 - (50 * 0.3);
                    apartament = 65 - (65 * 0.1);
                }
            }
            else if (Location == "June" || Location == "September")
            {
                studio = 75.20;
                apartament = 68.70;

                if (Nights > 14)
                {
                    studio = 75.20 - (75.20 * 0.2);
                    apartament = 68.70 - (68.70 * 0.1);
                }
            }
            else if (Location == "July" || Location == "August")
            {
                studio = 76;
                apartament = 77;
                if (Nights > 14)
                {
                    apartament = 77 - (77 * 0.1);
                }
            }

            Console.WriteLine($"Apartment: {(Nights * apartament):F2} lv.");
            Console.WriteLine($"Studio: {(Nights * studio):F2} lv.");
        }
    }
}