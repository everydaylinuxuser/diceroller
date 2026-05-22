using DiceRoller;
using System;
using Xunit;

namespace DiceRoller.Tests
{
    public class DiceTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(20)]
        public void Roll_ReturnsValueWithinRange(int sides)
        {
            for (int i = 0; i < 100; i++)
            {
                int result = Dice.Roll(sides);
                Assert.InRange(result, 1, sides);
            }
        }

        [Fact]
        public void Roll_ThrowsForLessThanTwo()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Dice.Roll(1));
        }
    }
}
