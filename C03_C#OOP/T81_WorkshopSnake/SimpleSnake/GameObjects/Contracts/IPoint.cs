using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Contracts
{
    public interface IPoint
    {
        int LeftX { get; set; }

        int TopY { get; set; }

        void Draw(char symbol);

        void Draw(int leftX,int topY, char symbol);
    }
}
