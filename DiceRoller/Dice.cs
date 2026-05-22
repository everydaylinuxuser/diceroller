using System;

namespace DiceRoller
{
    public static class Dice
    {
        private static readonly Random _rand = new Random();
        private static readonly object _lock = new object();

        public static int Roll(int sides)
        {
            if (sides < 2) throw new ArgumentOutOfRangeException(nameof(sides), "Dice must have at least 2 sides.");
            lock (_lock)
            {
                return _rand.Next(1, sides + 1);
            }
        }
    }
}
