using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Points.Foods
{
    public class FoodDollar : Food
    {
        private const char initialSymbol = '$';
        private const int initialPoints = 2;

        public FoodDollar(Wall wall)
            : base(wall, initialSymbol, initialPoints)
        {
        }
    }
}
