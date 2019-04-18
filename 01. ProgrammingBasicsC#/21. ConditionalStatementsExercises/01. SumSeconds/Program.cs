using System;

namespace sumSeconds1
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int sum;
            sum = a + b + c;
            if (sum % 60 == 0)
            {
                if (sum == 60)
                    Console.WriteLine("1:00");
                else
                {
                    if (sum < 10)
                        Console.WriteLine($"0:0{sum % 60}");
                    else
                        Console.WriteLine($"0:{sum}");
                }
            }
                
            else
            {
                if (sum % 60 < 10)
                    Console.WriteLine($"{sum / 60}:0{sum % 60}");
                else
                {
                        Console.WriteLine($"{sum / 60}:{sum % 60}");
                }
            }
        }
    }
}
