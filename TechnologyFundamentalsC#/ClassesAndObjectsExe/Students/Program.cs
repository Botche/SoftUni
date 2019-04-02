using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split();
                Student student = new Student
                {
                    FName = data[0]
                    ,
                    LName = data[1]
                    ,
                    Grade = double.Parse(data[2])
                };
                students.Add(student);
            }
            List<Student> sorted = students.OrderBy(x => x.Grade).ToList();
            sorted.Reverse();
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.FName} {item.LName}: {item.Grade:f2}");
            }
        }

        class Student
        {
            public string FName;
            public string LName;
            public double Grade; 
        }
    }
}
