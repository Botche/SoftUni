using System;

namespace cake
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int sum = 0,br1=0,br=0;
            sum = a * b;
            while (true)
            {
                string command = Console.ReadLine();
                
                if(command=="STOP")
                {
                    if (br1 > sum)
                    {
                         Console.WriteLine($"No more cake left! You need {br1 - sum} pieces more.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{sum-br1} pieces are left.");
                        break;
                    }
                }
                br = int.Parse(command);
                br1 += br;
                if(br1>sum)
                {
                    Console.WriteLine($"No more cake left! You need {br1 - sum} pieces more.");
                    break;
                }
                
            }
        }
    }
}
