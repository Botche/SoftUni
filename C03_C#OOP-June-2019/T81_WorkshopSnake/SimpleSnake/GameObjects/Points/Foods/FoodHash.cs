using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Points.Foods
{
    public class FoodHash : Food
    {
        private const char initialSymbol = '#';
        private const int initialPoints = 3;

        public FoodHash(Wall wall)
            : base(wall, initialSymbol, initialPoints)
        {
        }
    }
}
