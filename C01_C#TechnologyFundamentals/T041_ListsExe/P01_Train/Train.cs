using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandForPassangers = command.Split().ToArray();
                if (commandForPassangers[0] == "Add")
                {
                    int wagonWithPass = int.Parse(commandForPassangers[1]);
                    listOfWagons.Add(wagonWithPass);
                }
                else
                {
                    int passangers = int.Parse(commandForPassangers[0]);
                    for (int i = 0; i < listOfWagons.Count; i++)
                    {
                        if (listOfWagons[i] + passangers <= maxCapacityOfWagon)
                        {
                            listOfWagons[i] += passangers;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", listOfWagons));
        }
    }
}
