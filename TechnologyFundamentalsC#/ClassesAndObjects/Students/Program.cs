using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string[] input = Console.ReadLine()
                .Split();
            while (input[0] != "end")
            {
                string name = input[0];
                string familyName = input[1];
                int age = int.Parse(input[2]);
                string town = input[3];
                foreach (var sstudent in students)
                {
                    if (sstudent.Name == name && sstudent.FamilyName == familyName)
                    {
                        students.Remove(sstudent);
                        break;
                    }
                }
                Student student = new Student();

                student.Name = name;
                student.FamilyName = familyName;
                student.Age = age;
                student.Town = town;

                students.Add(student);

                input = Console.ReadLine()
                .Split();
            }
            string filter = Console.ReadLine();
            List<Student> filtered = students.
                    Where(x => x.Town == filter)
                    .ToList();
            foreach (var student in filtered)
            {
                Console.WriteLine($"{student.Name} {student.FamilyName} is {student.Age} years old.");
            }
        }
        class Student
        {
            public string Name;
            public string FamilyName;
            public int Age;
            public string Town { get; set; }
        }
    }
}
