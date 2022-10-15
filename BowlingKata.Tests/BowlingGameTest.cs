using Katas.Bowling;
using Xunit;

namespace Katas.Tests
{
    public class BowlingGameTest
    {
        private Game game;

        public BowlingGameTest()
        {
            game = new Game();
        }

        [Fact]
        public void ShouldStrikeAndRollFive()
        {
            game.Roll(10);
            game.Roll(0);
            game.Roll(5);
            RollMany(19, 0);
            var score = game.Score();

            Assert.Equal(20, score);
        }

        [Fact]
        public void ShouldHitFourPins()
        {
            game.Roll(4);
            var score = game.Score();

            Assert.Equal(4, score);
        }

        [Fact]
        public void ShouldGutterAllFrames()
        {
            RollMany(20, 0);

            var score = game.Score();

            Assert.Equal(0, score);
        }

        [Fact]
        public void ShouldShootOneInAllFrames()
        {
            RollMany(20, 1);

            var score = game.Score();

            Assert.Equal(20, score);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }

        [Fact]
        public void ShouldHitSpareAndFiveOnNextRoll()
        {
            game.Roll(4);
            game.Roll(6);

            game.Roll(5);
            game.Roll(2);

            var score = game.Score();

            Assert.Equal(22, score);
        }

        [Fact]
        public void ShouldHitPerfectRolls()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Roll(10);
                game.Roll(0);
            }

            game.Roll(10);
            game.Roll(10);
            game.Roll(10);


            var score = game.Score();

            Assert.Equal(300, score);
        }

        [Fact]
        public void ShouldHitOnlySpares()
        {
            for (int i = 0; i < 21; i++)
            {
                game.Roll(5);
            }

            var score = game.Score();

            Assert.Equal(150, score);
        }
    }
}
