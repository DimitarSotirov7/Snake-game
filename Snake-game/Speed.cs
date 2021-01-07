using System.Collections.Generic;

namespace Snake_game
{
    public static class Speed
    {
        private const string DefaultLevel = "2";

        public static int[] GetLevelSpeed(string level)
        {
            var levels = new Dictionary<string, int[]>()
            {
                { "1",  new int [2] { 100, 75 } },
                { "2",  new int [2] { 75, 50 } },
                { "3",  new int [2] { 50, 25 } },
                { "4",  new int [2] { 25, 5 } },
            };

            if (!levels.ContainsKey(level))
            {
                level = DefaultLevel;
            }

            return levels[level];
        }
    }
}
