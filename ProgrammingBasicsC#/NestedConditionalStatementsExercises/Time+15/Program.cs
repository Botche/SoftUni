using System;

namespace time_15
{
    class Program
    {
        static void Main()
        {
            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            if (m < 45)
            {
                Console.WriteLine($"{h}:{m+15}");
            }
            else
            {
                if (h == 23)
                {
                    if (m - 45 < 10)
                        Console.WriteLine($"0:0{m - 45}");
                    else
                        Console.WriteLine($"0:{m - 45}");
                }
                else
                {
                    if (m - 45 < 10)
                        Console.WriteLine($"{h + 1}:0{m - 45}");
                    else
                        Console.WriteLine($"{h+1}:{m - 45}");
                }
            }
        }
    }
}
