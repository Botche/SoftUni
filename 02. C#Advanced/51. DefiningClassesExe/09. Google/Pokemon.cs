using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Google
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Pokemon()
        {

        }
        public Pokemon(string name,string type)
        {
            Name = name;
            Type = type;
        }
    }
}
