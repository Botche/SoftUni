using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" : ");

            while (input[0]!="end")
            {
                string course = input[0];
                string student = input[1];

                if(!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(student);

                input = Console.ReadLine().Split(" : ");
            }
            var sorted = courses.OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var sort in sorted)
            {
                Console.WriteLine($"{sort.Key}: {sort.Value.Count}");
                sort.Value.Sort();
                foreach (var student in sort.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
