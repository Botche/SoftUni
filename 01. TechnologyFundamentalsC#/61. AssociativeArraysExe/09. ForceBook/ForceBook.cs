using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] force = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = force[0];
                    string forceUser = force[1];

                    if (!sides.ContainsKey(forceSide))
                        sides.Add(forceSide, new List<string>());

                    bool b = false;
                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            b = true;
                            break;
                        }
                    }
                    if (b == false)
                        sides[forceSide].Add(forceUser);
                }
                else
                {
                    string[] force = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = force[0];
                    string forceSide = force[1];

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                    if (!sides.ContainsKey(forceSide))
                        sides.Add(forceSide, new List<string>());

                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            sides[side.Key].Remove(forceUser);
                            break;
                        }
                    }

                    sides[forceSide].Add(forceUser);
                }

                input = Console.ReadLine();
            }
            var ordered = sides
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in ordered)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");
                    foreach (var user in side.Value.OrderBy(x => x).ToList())
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
