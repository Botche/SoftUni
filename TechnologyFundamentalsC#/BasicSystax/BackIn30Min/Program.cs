using System;

namespace backIn30Min
{
    class Program
    {
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());
            mins += 30;
            if (mins>=60)
            {
                hours++;
                if (hours > 23)
                {
                    if (mins - 60 < 10)
                        Console.WriteLine($"{hours - 24}:0{mins - 60}");
                    else
                        Console.WriteLine($"{hours - 24}:{mins - 60}");
                }
                else
                {
                    if (mins - 60 < 10)
                        Console.WriteLine($"{hours}:0{mins-60}");
                    else
                        Console.WriteLine($"{hours}:{mins-60}");
                }
            }
            else
            {
                if (mins < 10)
                    Console.WriteLine($"{hours}:0{mins}");
                else
                    Console.WriteLine($"{hours}:{mins}");
            }
        }
    }
}
