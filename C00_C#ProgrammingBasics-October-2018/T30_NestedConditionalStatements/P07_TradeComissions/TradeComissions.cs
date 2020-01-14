using System;

namespace tradeComissions
{
    class Program
    {
        static void Main()
        {
            string town = Console.ReadLine();
            double kg = double.Parse(Console.ReadLine());
           
                if(town=="Sofia")
                {
                    if(kg>=0 && kg<=500)
                        Console.WriteLine($"{kg*0.05:f2}");
                    else if (kg >500 && kg <= 1000)
                        Console.WriteLine($"{kg * 0.07:f2}");
                    else if (kg > 1000 && kg <= 10000)
                        Console.WriteLine($"{kg * 0.08:f2}");
                    else if (kg >10000)
                        Console.WriteLine($"{kg * 0.12:f2}");
                else Console.WriteLine("error");
            }
                else if(town=="Varna")
                {
                     if (kg >= 0 && kg <= 500)
                        Console.WriteLine($"{kg * 0.045:f2}");
                    else if (kg > 500 && kg <= 1000)
                        Console.WriteLine($"{kg * 0.075:f2}");
                    else if (kg > 1000 && kg <= 10000)
                        Console.WriteLine($"{kg * 0.10:f2}");
                    else if (kg > 10000)
                        Console.WriteLine($"{kg * 0.13:f2}");
                   else Console.WriteLine("error");
            }
                else if(town=="Plovdiv")
                {
                    if (kg >= 0 && kg <= 500)
                        Console.WriteLine($"{kg * 0.055:f2}");
                    else if (kg > 500 && kg <= 1000)
                        Console.WriteLine($"{kg * 0.08:f2}");
                    else if (kg > 1000 && kg <= 10000)
                        Console.WriteLine($"{kg * 0.12:f2}");
                    else if (kg > 10000)
                        Console.WriteLine($"{kg * 0.145:f2}");
                    else Console.WriteLine("error");
                }
                else Console.WriteLine("error");
        }
    }
}
