using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Google
{
    class Parents
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public Parents()
        {

        }
        public Parents(string name,DateTime birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }
    }
}
