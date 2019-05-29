using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestWithPass = new Dictionary<string, string>();
            string[] contest = Console.ReadLine()
                .Split(":",StringSplitOptions.RemoveEmptyEntries);

            while (contest[0] != "end of contests")
            {
                if (!contestWithPass.ContainsKey(contest[0]))
                {
                    contestWithPass.Add(contest[0], contest[1]);
                }
                else
                {
                    contestWithPass[contest[0]] = contest[1];
                }
                contest = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            Dictionary<string, Dictionary<string, int>> usersWithPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> candidatesWithPoints = new Dictionary<string, int>();
            string[] input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (input[0]!= "end of submissions")
            {
                string course = input[0];
                string pass = input[1];
                string user = input[2];
                int points = int.Parse(input[3]);

                if (contestWithPass.ContainsKey(course))
                {
                    if (contestWithPass[course]==pass)
                    {
                        if (!usersWithPoints.ContainsKey(user))
                        {
                            usersWithPoints.Add(user, new Dictionary<string, int>());
                            candidatesWithPoints.Add(user, 0);
                        }
                        if(usersWithPoints[user].ContainsKey(course))
                        {
                            if (points>usersWithPoints[user][course])
                            {
                                candidatesWithPoints[user] += points - usersWithPoints[user][course];
                                usersWithPoints[user][course] = points;
                            }
                        }
                        else
                        {
                            usersWithPoints[user].Add(course, points);
                            candidatesWithPoints[user] += points;
                        }
                    }
                }
                input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            var bestCandidate = candidatesWithPoints.OrderByDescending(x => x.Value);
            Console.WriteLine($"Best candidate is {bestCandidate.First().Key} with total {bestCandidate.FirstOrDefault().Value} points.");

            Console.WriteLine("Ranking:");

            foreach (var user in usersWithPoints.OrderBy(x=>x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var course in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
