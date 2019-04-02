using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] times = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int finishLine = times.Length / 2;
            double timeOfLeftPlayer = 0;
            for (int i = 0; i < finishLine; i++)
            {
                if (times[i] == 0)
                {
                    timeOfLeftPlayer *= 0.8;
                }
                else
                    timeOfLeftPlayer += times[i];
            }
            double timeOfRightPlayer = 0;
            for (int i = times.Length - 1; i > finishLine; i--)
            {
                if (times[i] == 0)
                {
                    timeOfRightPlayer *= 0.8;
                }
                else
                    timeOfRightPlayer += times[i];
            }
            if (timeOfLeftPlayer < timeOfRightPlayer)
            {
                Console.WriteLine($"The winner is left with total time: {Math.Round(timeOfLeftPlayer,1)}");
            }
            else if (timeOfLeftPlayer > timeOfRightPlayer)
            {
                Console.WriteLine($"The winner is right with total time: {Math.Round(timeOfRightPlayer, 1)}");
            }
        }
    }
}
