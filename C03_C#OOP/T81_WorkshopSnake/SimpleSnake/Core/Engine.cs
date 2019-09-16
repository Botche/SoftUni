using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Points;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private const Direction defaultSnakeDirection = Direction.Right;

        private Direction snakeDirection;

        private Snake snake;
        private Wall wall;
        private Point[] pointsOfDirection;

        public Engine(Wall wall, Snake snake)
        {
            this.snake = snake;
            this.wall = wall;
            pointsOfDirection = new Point[4];

            snakeDirection = defaultSnakeDirection;
        }

        public void Run()
        {
            double sleepTime = 200;
            this.CreateDirection();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake
                    .IsMoving(this.pointsOfDirection[(int)snakeDirection]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                if (sleepTime > 20)
                {
                    sleepTime -= 0.001;
                }

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int row = 7;
            int col = 5;
            Console.SetCursorPosition(row, col);
            Console.Write("Would you like");

            col += 4;
            row++;

            Console.SetCursorPosition(row, col);
            Console.Write("to continue?");

            col += 2;
            row++;

            Console.SetCursorPosition(row, col);
            Console.Write("Y/N");

            Console.SetCursorPosition(col, row + 1);
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }
        private void StopGame()
        {
            Console.Clear();

            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Game Over!!!");

            Thread.Sleep(1000000);
            Environment.Exit(0);
        }

        private void CreateDirection()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }
        private void GetNextDirection()
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
            {
                if (snakeDirection != Direction.Right)
                {
                    snakeDirection = Direction.Left;
                }
            }
            else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
            {
                if (snakeDirection != Direction.Left)
                {
                    snakeDirection = Direction.Right;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
            {
                if (snakeDirection != Direction.Up)
                {
                    snakeDirection = Direction.Down;
                }
            }
            else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
            {
                if (snakeDirection != Direction.Down)
                {
                    snakeDirection = Direction.Up;
                }
            }
            Console.CursorVisible = false;
        }
    }
}
