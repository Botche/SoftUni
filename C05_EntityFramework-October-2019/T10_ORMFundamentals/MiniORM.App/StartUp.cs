﻿using System.Linq;

using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

namespace MiniORM.App
{
    class StartUp
    {
        public static void Main()
        {
            var connectionString = @"Server=.\SQLEXPRESS;Database=MiniORM;Integrated Security=True;";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Imported",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
