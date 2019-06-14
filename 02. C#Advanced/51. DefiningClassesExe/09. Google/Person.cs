using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Google
{
    class Person
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Car Car { get; set; }
        public List<Children> Children { get; set; }
        public List<Parents> Parents { get; set; }
        public List<Pokemon> Pokemon { get; set; }

        public Person(string name)
        {
            Name = name;
            Company = new Company();
            Car = new Car();
            Children = new List<Children>();
            Parents = new List<Parents>();
            Pokemon = new List<Pokemon>();
        }



    }
}
