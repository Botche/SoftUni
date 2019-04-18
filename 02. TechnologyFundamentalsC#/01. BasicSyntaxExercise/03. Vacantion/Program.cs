using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int membersOfGroup = int.Parse(Console.ReadLine());
            string typeOfMembers = Console.ReadLine();
            string day = Console.ReadLine();
            double totalPrice = 0;
            if (typeOfMembers == "Students")
            {
                if (day == "Friday")
                {
                    totalPrice = 8.45;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 9.80;
                }
                else
                    totalPrice = 10.46;
                if (membersOfGroup >= 30)
                {
                    totalPrice *= 0.85;
                }
                Console.WriteLine($"Total price: {(totalPrice * membersOfGroup):f2}");
            }
            else if (typeOfMembers == "Business")
            {
                if (day == "Friday")
                {
                    totalPrice = 10.90;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 15.60;
                }
                else
                    totalPrice = 16;

                if (membersOfGroup >= 100)
                {
                    membersOfGroup -= 10;
                }
                Console.WriteLine($"Total price: {(totalPrice * membersOfGroup):f2}");
            }
            else
            {
                if (day == "Friday")
                {
                    totalPrice = 15;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 20;
                }
                else
                    totalPrice = 22.50;

                if (membersOfGroup >= 10 && membersOfGroup <= 20)
                {
                    totalPrice *= 0.95;
                }
                Console.WriteLine($"Total price: {(totalPrice * membersOfGroup):f2}");
            }

        }
    }
}
