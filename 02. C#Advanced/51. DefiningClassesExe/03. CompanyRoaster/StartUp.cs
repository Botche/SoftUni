using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string name = input[0];
                double salary = double.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = null;
                int age = 0;
                if (input.Length==6)
                {
                    email = input[4];
                    age = int.Parse(input[5]);
                }
                else if (input.Length==5)
                {
                    if (char.IsDigit(input[4][0]))
                    {
                        age = int.Parse(input[5]);
                    }
                    else
                    {
                        email = input[4];
                    }
                }
                Employee employee = new Employee()
                {
                    Name = name,
                    Salary=salary,
                    Position=position,
                    Department=department
                };
                if (email!=null)
                {
                    employee.Email = email;
                }
                if (age!=0)
                {
                    employee.Age = age;
                }
                employees.Add(employee);
            }
            string departmentWithHighAverageSalary = employees.GroupBy(x => x.Department)
                .OrderByDescending(y => y.Select(s => s.Salary).Average())
                .FirstOrDefault()
                .Key;
            Console.WriteLine($"Highest Average Salary: {departmentWithHighAverageSalary}");

            foreach (var employee in employees.Where(x => x.Department == departmentWithHighAverageSalary).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
