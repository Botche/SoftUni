using System;

namespace moving
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int n,sum1,sum2=0;
            sum1 = a * b * h;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Done")
                {
                    if (sum2 <= sum1)
                    {
                        Console.WriteLine($"{sum1 - sum2} Cubic meters left.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"No more free space! You need {sum2 - sum1} Cubic meters more.");
                        break;
                    }
                }

                n = int.Parse(command);
                sum2 += n;

                if(sum2>sum1)
                {
                    Console.WriteLine($"No more free space! You need {sum2 - sum1} Cubic meters more.");
                    break;
                }
            }
        }
    }
}
