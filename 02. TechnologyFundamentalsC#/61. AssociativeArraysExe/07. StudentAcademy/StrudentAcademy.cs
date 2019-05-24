using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < length; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                    students.Add(name, new List<double>());
                students[name].Add(grade);
            }

            var selectedStudents = students
                .OrderByDescending(x=>x.Value.Average())
                .Where(x => x.Value.Average() >= 4.50)
                .ToDictionary(x => x.Key, x => x.Value);

            
            foreach (var student in selectedStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
