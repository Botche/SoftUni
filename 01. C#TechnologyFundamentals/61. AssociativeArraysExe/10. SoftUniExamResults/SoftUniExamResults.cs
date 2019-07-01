using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("-");
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            while (input[0] != "exam finished")
            {
                string username = input[0];
                string language = input[1];
                int points = 0;
                if (language != "banned")
                {
                    points = int.Parse(input[2]);

                    if (!students.ContainsKey(username))
                        students.Add(username, points);
                    if (students[username] < points)
                        students[username] = points;

                    if (!counts.ContainsKey(language))
                        counts.Add(language, 1);
                    else
                        counts[language]++;
                }
                else
                {
                    students.Remove(username);
                }
                input = Console.ReadLine().Split("-");
            }
            var sortedStudents = students.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }
            Console.WriteLine("Submissions:");
            var sorted = counts.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var count in sorted)
            {
                Console.WriteLine($"{count.Key} - {count.Value}");
            }
        }
    }
}
