using System;

namespace Snake_game
{
    class Directions
    {
        private bool started = false;

        private Position right;
        private Position left;
        private Position up;
        private Position down;

        public Directions()
        {
            this.right = new Position(1, 0);
            this.left = new Position(-1, 0);
            this.up = new Position(0, -1);
            this.down = new Position(0, 1);
        }

        private Position CurrentDirection { get; set; } = new Position(1, 0);

        private Position PreviousDirection { get; set; } = new Position(1, 0);

        public Position setNextDirection()
        {
            if (Console.KeyAvailable || this.started == false)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key.Equals(ConsoleKey.RightArrow) && this.PreviousDirection != this.left)
                {
                    this.CurrentDirection = this.right;
                    this.PreviousDirection = this.right;
                }
                else if (userInput.Key.Equals(ConsoleKey.LeftArrow) && this.PreviousDirection != this.right)
                {
                    this.CurrentDirection = this.left;
                    this.PreviousDirection = this.left;
                }
                else if (userInput.Key.Equals(ConsoleKey.UpArrow) && this.PreviousDirection != this.down)
                {
                    this.CurrentDirection = this.up;
                    this.PreviousDirection = this.up;
                }
                else if (userInput.Key.Equals(ConsoleKey.DownArrow) && this.PreviousDirection != this.up)
                {
                    this.CurrentDirection = this.down;
                    this.PreviousDirection = this.down;
                }
                else if (userInput.Key.Equals(ConsoleKey.P))
                {
                    Paused();
                }
                else if (userInput.Key.Equals(ConsoleKey.R))
                {
                    return new Position(-1, -1);
                }
            }

            this.started = true;

            return this.CurrentDirection;
        }

        public void Paused()
        {
            Console.Clear();

            string welcomeMessage = "Game is paused! Press [P] to continue.";
            int left = (Console.BufferWidth / 2) - (welcomeMessage.Length / 2);
            int top = Console.BufferHeight / 2;
            Console.SetCursorPosition(left, top);
            Console.Write(welcomeMessage);

            while (true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key.Equals(ConsoleKey.P))
                {
                    break;
                }
            }
        }
    }
}
