using System;
using System.Threading;

namespace Snake_game
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.StartPage();
            board.GenerateFood();

            Position position = new Position();
            Snake snake = new Snake();
            snake.InitializeSnake(position);

            Directions direction = new Directions();

            while (true)
            {
                try
                {
                    foreach (var elements in snake.SnakeElements)
                    {
                        Console.SetCursorPosition(elements.Row, elements.Col);
                        Console.Write(snake.Symbol);
                    }

                    snake.Moving(direction.setNextDirection(), board.FoodPositions);
                }
                catch (ArgumentOutOfRangeException)
                {
                    var resetGame = board.GameOver(snake);

                    if (resetGame)
                    {
                        Console.Clear();
                        Main(null);
                    }

                    Environment.Exit(0);
                }
                
                board.SetFood();

                int speedOfSnake = (snake.Points * 5) > 50 ? 50 : (snake.Points * 5);

                Thread.Sleep(100 - speedOfSnake);
                Console.Clear();
            }
        }
    }
}