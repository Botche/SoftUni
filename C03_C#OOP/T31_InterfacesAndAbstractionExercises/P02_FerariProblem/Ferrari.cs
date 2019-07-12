using System;
using System.Collections.Generic;
using System.Text;

namespace FerrariProblem
{
    public class Ferrari : ICar
    {
        public Ferrari(string name)
        {
            Name = name;
            Model = "488-Spider";
        }

        public string Name { get; set; }
        public string Model { get; set; }

        public string Break()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }
    }
}
