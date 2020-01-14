using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] input = Console.ReadLine().Split();
                Employee employee = new Employee();
                employee.Name = input[0];
                employee.Salary = double.Parse(input[1]);
                employee.Department = input[2];

                employees.Add(employee);
            }

            var result = employees
                    .GroupBy(e => e.Department)
                    .Select(e => new
                    {
                        Department = e.Key,
                        AverageSalary = e.Average(emp => emp.Salary),
                        Employees = e.OrderByDescending(emp => emp.Salary)
                    })
                    .OrderByDescending(x=>x.AverageSalary)
                    .ToList();

            Console.WriteLine($"Highest Average Salary: {result[0].Department}");
            foreach (var employee in result[0].Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} ");
            }

        }
    }

    class Employee
    {
        public string Name;
        public double Salary;
        public string Department;

    }
}
