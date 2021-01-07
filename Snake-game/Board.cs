using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_game
{
    public class Board
    {
        private const int DefaultHeight = 30;
        private const int DefaultWidth = 120;

        private const int DefaultFoods = 10;

        public Board()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.OutputEncoding = Encoding.Unicode;

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

        public string GameLevel { get; private set; }

        public char Food { get; private set; } = '©';

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

        public bool StartPage()
        {
            PrintMessageInMiddle("Welcome to my Snake Game.");
            PrintMessageInMiddle("Press [Enter] to continue.", 2);
            PrintMessageInMiddle("Tap [R] at any time when you want to reset the game.", 4);

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key.Equals(ConsoleKey.Enter))
                {
                    Console.Beep(1000, 3);
                    this.GameLevel = this.SetGameLevel();

                    Console.Clear();
                    Console.Beep(1000, 3);
                    return false;
                }
                else
                {
                    Console.Clear();
                    return true;
                }
            }
        }

        private string SetGameLevel()
        {
            Console.Clear();
            PrintMessageInMiddle("Select an option to set the snake speed.");
            PrintMessageInMiddle("Tap [1] for Slow", 2);
            PrintMessageInMiddle("Tap [2] for Medium", 4);
            PrintMessageInMiddle("Tap [3] for Fast", 6);
            PrintMessageInMiddle("Tap [4] for Fast and Furious", 8);

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                var exit = (pressedKey.Key.Equals(ConsoleKey.D1) || pressedKey.Key.Equals(ConsoleKey.NumPad1)) ||
                    (pressedKey.Key.Equals(ConsoleKey.D2) || pressedKey.Key.Equals(ConsoleKey.NumPad2)) ||
                    (pressedKey.Key.Equals(ConsoleKey.D3) || pressedKey.Key.Equals(ConsoleKey.NumPad3)) ||
                    (pressedKey.Key.Equals(ConsoleKey.D4) || pressedKey.Key.Equals(ConsoleKey.NumPad4));
                if (exit)
                {
                    return pressedKey.KeyChar.ToString();
                }
            }
        }

        public bool GameOver(Snake snake)
        {
            Console.Beep(1500, 30);
            Console.Clear();

            PrintMessageInMiddle("Game Over!");
            PrintMessageInMiddle($"Your points: {snake.Points}", 2);
            PrintMessageInMiddle($"Press [Esc] to close or [R] to reset game.", 4);

            bool restart = false;

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key.Equals(ConsoleKey.Escape))
                {
                    break;
                }
                else if (pressedKey.Key.Equals(ConsoleKey.R))
                {
                    restart = true;
                    break;
                }
            }

            Console.Beep(1000, 3);
            return restart;
        }

        private void PrintMessageInMiddle(string message, int topRows = 0)
        {
            int left = (Console.BufferWidth / 2) - (message.Length / 2);
            int top = Console.BufferHeight / 2 - 4 + topRows;
            Console.SetCursorPosition(left, top);
            Console.Write(message);
        }
    }
}
