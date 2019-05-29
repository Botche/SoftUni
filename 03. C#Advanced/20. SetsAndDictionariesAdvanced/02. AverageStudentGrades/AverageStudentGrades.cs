using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> gradesOfStudents
                = new Dictionary<string, List<double>>();
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string student = input[0];
                double grade = double.Parse(input[1]);

                if (!gradesOfStudents.ContainsKey(student))
                {
                    gradesOfStudents.Add(student, new List<double>());
                }
                gradesOfStudents[student].Add(grade);
            }

            foreach (var student in gradesOfStudents)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
