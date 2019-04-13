using System;

namespace fruitShop
{ 
    class Program
    {
        static void Main()
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double kg = double.Parse(Console.ReadLine());
            if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "apple")
                    Console.WriteLine($"{kg * 1.25:f2}");
                else if (fruit == "banana")
                    Console.WriteLine($"{kg * 2.70:f2}");
                else if (fruit == "orange")
                    Console.WriteLine($"{kg * 0.90:f2}");
                else if (fruit == "grapefruit")
                    Console.WriteLine($"{kg * 1.60:f2}");
                else if (fruit == "kiwi")
                    Console.WriteLine($"{kg * 3.00:f2}");
                else if (fruit == "pineapple")
                    Console.WriteLine($"{kg * 5.60:f2}");
                else if (fruit == "grapes")
                    Console.WriteLine($"{kg * 4.20:f2}");
                else
                    Console.WriteLine("error");
            }
            else if(day=="Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "apple")
                    Console.WriteLine($"{kg * 1.20:f2}");
                else if (fruit == "banana")
                    Console.WriteLine($"{kg * 2.50:f2}");
                else if (fruit == "orange")
                    Console.WriteLine($"{kg * 0.85:f2}");
                else if (fruit == "grapefruit")
                    Console.WriteLine($"{kg * 1.45:f2}");
                else if (fruit == "kiwi")
                    Console.WriteLine($"{kg * 2.70:f2}");
                else if (fruit == "pineapple")
                    Console.WriteLine($"{kg * 5.50:f2}");
                else if (fruit == "grapes")
                    Console.WriteLine($"{kg * 3.85:f2}");
                else
                    Console.WriteLine("error");
            }
            else
                Console.WriteLine("error");
        }
    }
}
