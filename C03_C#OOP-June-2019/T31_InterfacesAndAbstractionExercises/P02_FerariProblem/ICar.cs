using System;
using System.Collections.Generic;
using System.Text;

namespace FerrariProblem
{
    public interface ICar
    {
        string Name { get; set; }
        string Model { get; set; }

        string Gas();
        string Break();
    }
}
