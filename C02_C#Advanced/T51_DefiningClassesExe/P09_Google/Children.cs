using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Google
{
    class Children
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public Children()
        {

        }
        public Children(string name, DateTime birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }
    }
}
