using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be null or negative.");
                }
                width = value;
            }
        }
        public int Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be null or negative.");
                }
                height = value;
            }
        }

        public void Draw()
        {
            DrawLine('*', '*');

            for (int i = 1; i < Height - 1; i++)
            {
                DrawLine('*', ' ');
            }

            DrawLine('*', '*');
        }

        private void DrawLine(char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < Width - 1; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
