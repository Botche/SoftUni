using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(":");
            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (input[0] != "end of contests")
            {
                string contest = input[0];
                string pass = input[1];

                contests.Add(contest, pass);

                input = Console.ReadLine()
                .Split(":");
            }

            input = Console.ReadLine()
                .Split("=>");
            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();
            while (input[0] != "end of submissions")
            {
                string contest = input[0];
                string pass = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    if (!submissions.ContainsKey(username))
                    {
                        submissions.Add(username, new Dictionary<string, int>());
                    }
                    if (!submissions[username].ContainsKey(contest))
                    {
                        submissions[username].Add(contest, points);
                    }
                    else
                    {
                        if (submissions[username][contest] < points)
                            submissions[username][contest] = points;
                    }
                }
                input = Console.ReadLine()
                    .Split("=>");
            }
            string bUser = "";
            int maxPoints = 0,sum=0;
            foreach (var user in submissions)
            {
                foreach (var points in user.Value)
                {
                    sum += points.Value;
                }
                if(maxPoints<sum)
                {
                    maxPoints = sum;
                    bUser = user.Key;
                }
                sum = 0;
            }

            Console.WriteLine($"Best candidate is {bUser} with total {maxPoints} points.");

            Console.WriteLine("Ranking:");
            var sorted = submissions.OrderBy(x => x.Key).ToDictionary(x=>x.Key,z=>z.Value);
            foreach (var user in sorted)
            {
                Console.WriteLine(user.Key);
                var sortedSubm = user.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, z => z.Value);
                foreach (var subm in sortedSubm)
                {
                    Console.WriteLine($"#  {subm.Key} -> {subm.Value}");
                }
            }
        }
    }
}
