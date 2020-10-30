using System;

namespace Snake_game
{
    class Directions
    {
        private bool started = false;
        private bool paused = false;

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

        private Position CurrentDirection { get; set; }

        private Position PreviousDirection { get; set; }

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
            }

            this.started = true;

            return this.CurrentDirection;
        }

        //public bool Paused()
        //{
        //    if (Console.KeyAvailable)
        //    {
        //        ConsoleKeyInfo userInput = Console.ReadKey();

        //        if (userInput.Key.Equals(ConsoleKey.P))
        //        {
        //            if (this.paused)
        //            {
        //                paused = false;
        //            }
        //            else
        //            {
        //                paused = true;
        //            }
        //        }
        //    }

        //    return this.paused;
        //}
    }
}
