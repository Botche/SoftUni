using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoaster
{
    class Employee
    {
        private string name;
        private double salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Employee()
        {
            Email = "n/a";
            Age = -1;
        }

    }
}
