using System;

namespace Snake_game
{
    public class Board
    {
        private const int DefaultHeight = 30;
        private const int DefaultWidth = 120;

        private const int DefaultFoods = 5;

        public Board()
        {
            Console.BufferHeight = Console.WindowHeight;

            Console.BufferHeight = DefaultHeight;
            Console.BufferWidth = DefaultWidth;

            this.FoodPositions = new Position[DefaultFoods];
        }

        public Board(int height, int width)
            :this()
        {
            Console.BufferHeight = height;
            Console.BufferWidth = width;
        }

        public char Food { get; private set; } = '@';

        public Position[] FoodPositions { get; private set; }

        public void GenerateFood()
        {
            Random generateNumber = new Random();

            for (int i = 0; i < DefaultFoods; i++)
            {
                int row = generateNumber.Next(0, Console.BufferWidth);
                int col = generateNumber.Next(0, Console.BufferHeight);

                this.FoodPositions[i] = new Position(row, col);
            }
        }

        public void SetFood()
        {
            foreach (var foodPosition in this.FoodPositions)
            {
                Console.SetCursorPosition(foodPosition.Row, foodPosition.Col);
                Console.Write(this.Food);
            }
        }

        public void StartPage()
        {
            string welcomeMessage = "Welcome to my Snake Game. Press [Enter] to continue.";

            int left = (Console.BufferWidth / 2) - (welcomeMessage.Length / 2);
            int top = Console.BufferHeight / 2;

            Console.SetCursorPosition(left, top);
            Console.Write(welcomeMessage);

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key.Equals(ConsoleKey.Enter))
                {
                    Console.Clear();
                    break;
                }
            }
        }

        public bool GameOver(Snake snake)
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Your points: {snake.Points}");
            Console.WriteLine($"Press [Esc] to close or [R] to reset game.");

            var resetGame = false;

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key.Equals(ConsoleKey.Escape))
                {
                    break;
                }

                if (pressedKey.Key.Equals(ConsoleKey.R))
                {
                    resetGame = true;
                    break;
                }
            }

            return resetGame;
        }
    }
}
