using SimpleSnake.GameObjects.Points;
using SimpleSnake.GameObjects.Points.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';
        private Queue<Point> snakeElements;

        private Wall wall;

        private Food[] foods;

        private int foodIndex;
        private int RandomFoodNumber =>
            new Random().Next(0, foods.Length);

        private int nextLeftX;
        private int nextTopY;

        public Snake(Wall wall)
        {
            this.wall = wall;

            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];

            this.foodIndex = RandomFoodNumber;

            this.GetFoods();
            this.CreateSnake();

            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeNewHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            // int leftX = currentSnakeHead.LeftX;
            // int topY = currentSnakeHead.TopY;

            // GetNextPoint(direction, currentSnakeHead);
            for (int i = 0; i < length; i++)
            {
                var point = new Point(this.nextLeftX, this.nextTopY);
                this.snakeElements.Enqueue(point);

                // point.Draw(snakeSymbol);
                // leftX += direction.LeftX;
                // topY += direction.TopY;

                GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }
        
        private void GetFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction,Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
    }
}
