using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int numberOfCommands = int.Parse(Console.ReadLine());
            string command = "";
            for (int i = 0; i < numberOfCommands; i++)
            {
                command = Console.ReadLine();
                string[] guestsMoving = command.Split().ToArray();
                if (guestsMoving.Length == 3)
                {
                    if (guests.Contains(guestsMoving[0]))
                        Console.WriteLine($"{guestsMoving[0]} is already in the list!");
                    else
                        guests.Add(guestsMoving[0]);
                }
                else
                {
                    if (guests.Contains(guestsMoving[0]))
                        guests.Remove(guestsMoving[0]);
                    else
                        Console.WriteLine($"{guestsMoving[0]} is not in the list!");
                }
            }
            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
