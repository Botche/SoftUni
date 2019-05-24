using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bandsWithMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandsWithTime = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split("; ");

            while (input[0]!="start of concert")
            {
                string command = input[0];
                string bandName = input[1];

                if(command=="Add")
                {
                    string[] members = input[2].Split(", ");

                    if (!bandsWithMembers.ContainsKey(bandName))
                        bandsWithMembers.Add(bandName, new List<string>());
                    foreach (var member in members)
                    {
                        if (!bandsWithMembers[bandName].Contains(member))
                            bandsWithMembers[bandName].Add(member);
                    }
                }
                else if(command=="Play")
                {
                    int time = int.Parse(input[2]);

                    if (!bandsWithTime.ContainsKey(bandName))
                        bandsWithTime.Add(bandName, time);
                    else
                        bandsWithTime[bandName] += time;

                }
                input = Console.ReadLine().Split("; ");
            }
            string groupToPrint = Console.ReadLine();
            var sortedBandsWithTime = bandsWithTime.OrderByDescending(x => x.Value).ThenBy(x=>x.Key);
            var totalTime = bandsWithTime.Sum(x => x.Value);

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var band in sortedBandsWithTime)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }
           
            var group = bandsWithMembers.Where(x=>x.Key== groupToPrint).First();
            Console.WriteLine(group.Key);
            foreach (var member in group.Value)
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
