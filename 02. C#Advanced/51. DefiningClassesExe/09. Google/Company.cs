using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Google
{
    class Company
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public Company()
        {

        }
        public Company(string name,string department,double salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }
    }
}
