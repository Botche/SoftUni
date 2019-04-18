using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" -> ");
            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> individualStats = new Dictionary<string, int>();
            while (input[0] != "no more time")
            {
                string username = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);

                if (!submissions.ContainsKey(contest))
                {
                    submissions.Add(contest, new Dictionary<string, int>());
                }
                if (!submissions[contest].ContainsKey(username))
                {
                    submissions[contest].Add(username, points);
                }
                else
                {
                    if (submissions[contest][username] < points)
                        submissions[contest][username] = points;
                }
                input = Console.ReadLine()
                .Split(" -> ");
            }
            foreach (var contest in submissions)
            {
                foreach (var user in contest.Value)
                {
                    if (!individualStats.ContainsKey(user.Key))
                        individualStats.Add(user.Key, user.Value);
                    else
                        individualStats[user.Key] += user.Value;
                }
            }
            int count = 1;
            foreach (var subm in submissions)
            {
                Console.WriteLine($"{subm.Key}: {subm.Value.Count()} participants");
                var sortedSubm = subm.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, z => z.Value);
                foreach (var item in sortedSubm)
                {
                    Console.WriteLine($"{count++}. {item.Key} <::> {item.Value}");
                }
                count = 1;
            }

            count = 1;
            Console.WriteLine("Individual standings:");
            var sortedInd = individualStats.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, z => z.Value);
            foreach (var user in sortedInd)
            {
                Console.WriteLine($"{count++}. {user.Key} -> {user.Value}");
            }
        }
    }
}

