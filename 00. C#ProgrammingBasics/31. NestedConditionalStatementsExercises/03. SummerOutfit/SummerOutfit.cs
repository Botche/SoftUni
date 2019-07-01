using System;

namespace summerOutfit
{
    class Program
    {
        static void Main()
        {
            int deg = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            if(deg>=10 && deg<=18)
            {
                if(time=="Morning")
                    Console.WriteLine($"It's {deg} degrees, get your Sweatshirt and Sneakers.");
                else if(time=="Afternoon")
                    Console.WriteLine($"It's {deg} degrees, get your Shirt and Moccasins.");
                else if (time == "Evening")
                    Console.WriteLine($"It's {deg} degrees, get your Shirt and Moccasins.");
            }
            else if(deg>18 && deg<=24)
            {
                if (time == "Morning")
                    Console.WriteLine($"It's {deg} degrees, get your Shirt and Moccasins.");
                else if (time == "Afternoon")
                    Console.WriteLine($"It's {deg} degrees, get your T-Shirt and Sandals.");
                else if (time == "Evening")
                    Console.WriteLine($"It's {deg} degrees, get your Shirt and Moccasins.");
            }
            else
            {
                if (time == "Morning")
                    Console.WriteLine($"It's {deg} degrees, get your T-Shirt and Sandals.");
                else if (time == "Afternoon")
                    Console.WriteLine($"It's {deg} degrees, get your Swim Suit and Barefoot.");
                else if (time == "Evening")
                    Console.WriteLine($"It's {deg} degrees, get your Shirt and Moccasins.");
            }
        }
    }
}
