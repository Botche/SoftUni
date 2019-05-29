using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            while (input[0] != "Statistics")
            {
                string command = input[1];
                string vloggerName = input[0];

                if (command == "joined" && !vloggers.ContainsKey(vloggerName))
                {
                    vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                    vloggers[vloggerName].Add("followers", new HashSet<string>());
                    vloggers[vloggerName].Add("following", new HashSet<string>());
                }
                else if (command == "followed")
                {
                    string followedVlogger = input[2];
                    if (vloggerName != followedVlogger && vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(followedVlogger))
                    {
                        vloggers[vloggerName]["following"].Add(followedVlogger);
                        vloggers[followedVlogger]["followers"].Add(vloggerName);
                    }
                }
                input = Console.ReadLine()
                .Split();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var vlogger in vloggers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
