using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Points.Foods
{
    public class FoodAsterisk : Food
    {
        private const char initialSymbol = '*';
        private const int initialPoints = 1;

        public FoodAsterisk(Wall wall)
            : base(wall, initialSymbol, initialPoints)
        {
        }
    }
}
