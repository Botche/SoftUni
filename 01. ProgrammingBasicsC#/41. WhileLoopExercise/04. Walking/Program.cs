using System;

namespace walking
{
    class Program
    {
        static void Main()
        {
            int steps = 0,sum=0;

            do
            {
                string command = Console.ReadLine();
                if (command == "Going home")
                {
                    command = Console.ReadLine();
                    steps = int.Parse(command);
                    sum += steps;
                    if (sum < 10000)
                        Console.WriteLine($"{10000 - sum} more steps to reach goal.");
                    else
                        Console.WriteLine("Goal reached! Good job!");
                    break;
                }
                
                steps = int.Parse(command);
                sum += steps;
                if (sum >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    break;
                }
            } while (sum <= 10000);
        }
    }
}
