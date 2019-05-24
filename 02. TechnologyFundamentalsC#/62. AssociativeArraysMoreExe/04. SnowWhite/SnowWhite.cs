using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" <:> ");
            Dictionary<string, Dictionary<string, int>> dwarves = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> forTheWin = new Dictionary<string, int>();
            while (input[0] != "Once upon a time")
            {
                string name = input[0];
                string hatColor = input[1];
                int physics = int.Parse(input[2]);

                if (!dwarves.ContainsKey(hatColor))
                {
                    dwarves.Add(hatColor, new Dictionary<string, int>());
                    dwarves[hatColor].Add(name, physics);
                    forTheWin.Add(hatColor, physics);
                }
                else
                {
                    if (dwarves[hatColor].ContainsKey(name))
                    {
                        if (dwarves[hatColor][name] < physics)
                        {
                            dwarves[hatColor][name] = physics;
                            forTheWin[hatColor] = physics;
                        }
                    }
                    else
                    {
                        dwarves[hatColor].Add(name, physics);
                        forTheWin.Add(hatColor, physics);
                    }
                }
                input = Console.ReadLine()
                .Split(" <:> ");
            }


            var sorted = forTheWin.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var hatColor in sorted)
            {
                string name = "";
                foreach (var dwarf in dwarves.Where(x => x.Key == hatColor.Key))
                {
                    foreach (var physics in dwarf.Value)
                    {
                        if (physics.Value == hatColor.Value)
                        {
                            name = physics.Key;
                            break;
                        }
                    }
                }
                Console.WriteLine($"({hatColor.Key}) {name} <-> {hatColor.Value}");
            }
        }
    }
}