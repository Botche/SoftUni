using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    class Vegetable
    {
        public string Name { get;private set; }
        public int Calories { get;private set; }

        public Vegetable(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public override string ToString()
        {
            return $" - {Name} have {Calories} calories";
        }
    }
}
