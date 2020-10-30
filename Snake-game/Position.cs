namespace Snake_game
{
    public class Position
    {
        public Position(int row = 0, int col = 1)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }
    }
}
