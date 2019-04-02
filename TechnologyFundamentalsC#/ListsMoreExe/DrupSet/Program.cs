using System;
using System.Collections.Generic;
using System.Linq;

namespace DrupSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> oldDrumSet = new List<int>();
            foreach (var item in drumSet)
            {
                oldDrumSet.Add(item);
            }
            string command = Console.ReadLine();
            while (command!= "Hit it again, Gabsy!")
            {
                int power = int.Parse(command);
                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= power;
                    if(drumSet[i]<=0)
                    {
                        if(oldDrumSet[i]*3<=savings)
                        {
                            drumSet[i] = oldDrumSet[i];
                            savings -= oldDrumSet[i] * 3;
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            oldDrumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
