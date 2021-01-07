using System;
using System.Threading;

namespace Snake_game
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            bool restart = board.StartPage();

            if (restart)
            {
                Main(null);
            }

            string level = board.GameLevel;

            board.GenerateFood();

            Position position = new Position();
            Snake snake = new Snake();
            snake.InitializeSnake(position);

            Directions direction = new Directions();

            int[] speedLevels = Speed.GetLevelSpeed(level);
            int startSpeed = speedLevels[0];
            int endSpeed = speedLevels[1];

            while (true)
            {
                try
                {
                    foreach (var elements in snake.SnakeElements)
                    {
                        Console.SetCursorPosition(elements.Row, elements.Col);
                        Console.Write(snake.Symbol);
                    }

                    var nextDirection = direction.setNextDirection();

                    if (nextDirection.Row == -1 && nextDirection.Col == -1)
                    {
                        Console.Clear();
                        Main(null);
                    }

                    snake.Moving(nextDirection, board.FoodPositions);
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (board.GameOver(snake))
                    {
                        Console.Clear();
                        Main(null);
                    }

                    Environment.Exit(0);
                }
                
                board.SetFood();

                int speedOfSnake = startSpeed - (snake.Points * 2) < endSpeed ? endSpeed : startSpeed - (snake.Points * 2);
                Thread.Sleep(speedOfSnake);
                Console.Clear();
            }
        }
    }
}