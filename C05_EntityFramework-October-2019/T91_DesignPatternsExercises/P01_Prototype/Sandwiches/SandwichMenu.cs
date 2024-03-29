﻿using System.Collections.Generic;
using P01_Prototype.Prototypes;

namespace P01_Prototype.Sandwiches
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> _sandwiches = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get
            {
                return _sandwiches[name];
            }
            set
            {
                _sandwiches.Add(name, value);
            }
        }
    }
}
