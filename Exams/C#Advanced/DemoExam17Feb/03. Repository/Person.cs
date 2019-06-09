using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Repository
{
    class Person
    {
        private string name;
        private int age;
        private DateTime birthDay;

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }

        public Person(string name,int age,DateTime birthdate)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }
    }
}
