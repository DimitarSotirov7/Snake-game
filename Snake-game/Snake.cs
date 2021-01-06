using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Snake_game
{
    public class Snake
    {
        private const int DefaultLength = 10;
        private int initalSnakeElements;

        public Snake()
        {
            this.SnakeElements = new Queue<Position>();

            this.initalSnakeElements = DefaultLength;
        }

        public Snake(int initalSnakeElements)
            : this()
        {
            this.initalSnakeElements = initalSnakeElements;
        }

        private Position Head { get; set; }

        public char Symbol { get; private set; } = '*';

        public int Points { get; private set; }

        public Queue<Position> SnakeElements { get; private set; }

        public void InitializeSnake(Position possition)
        {
            for (int i = 0; i < initalSnakeElements; i++)
            {
                this.SnakeElements.Enqueue(new Position(i, possition.Col));
            }
        }

        public void Moving(Position nextPosition, Position[] foodPositions)
        {
            int nextRow = nextPosition.Row;
            int nextCol = nextPosition.Col;

            this.Head = this.SnakeElements.Last();
            Position snakeNewHead = new Position(this.Head.Row + nextRow, this.Head.Col + nextCol);

            if (this.HitBody(snakeNewHead))
            {
                throw new ArgumentOutOfRangeException();
            }

            SnakeElements.Enqueue(snakeNewHead);

            if (!this.FeedingChecker(snakeNewHead, foodPositions))
            {
                SnakeElements.Dequeue();
            }
            else
            {
                this.Points++;
                Console.Beep(1000, 3);
            }
        }

        public bool FeedingChecker(Position snakeNewHead, Position[] foodPositions)
        {
            for (int i = 0; i < foodPositions.Length; i++)
            {
                if (snakeNewHead.Row == foodPositions[i].Row && snakeNewHead.Col == foodPositions[i].Col)
                {
                    Random generateNewFood = new Random();
                    foodPositions[i] = new Position
                    (
                        generateNewFood.Next(0, Console.BufferWidth),
                        generateNewFood.Next(0, Console.BufferHeight)
                    );

                    return true;
                }
            }

            return false;
        }

        public bool HitBody(Position snakeNewHead)
        {
            foreach (var element in this.SnakeElements)
            {
                if (element.Row == snakeNewHead.Row && element.Col == snakeNewHead.Col)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
