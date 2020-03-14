using ConnectFour.Logic;
using System;
using Xunit;

namespace ConnectFour.Tests
{
    public class BoardTests
    {
        [Fact]
        public void AddWithInvalidColumnIndex()
        {
            var b = new Board();

            Assert.Throws<ArgumentOutOfRangeException>(() => b.AddStone(7));

        }

        [Fact]
        public void PlayerChangesWhenAddingStone()
        {
            var b = new Board();

            var oldPlayer = b.Player;
            b.AddStone(0);

            // Verify that player has changed
            Assert.NotEqual(oldPlayer, b.Player);
        }

        [Fact]
        public void AddingTooManyStonesToAColumn()
        {
            var b = new Board();

            for(var i=0; i<6; i++)
            {
                b.AddStone(0);
            }

            var oldPlayer = b.Player;
            Assert.Throws<InvalidOperationException>(() => b.AddStone(0));
            Assert.Equal(oldPlayer, b.Player);
        }
        [Fact]
        public void CorrectlyPlacedStones()
        {
            var b = new Board();
            var oldPlayer = b.Player;

            b.AddStone(0);

            Assert.Equal(b.GetBoard()[0, 0], oldPlayer + 1);
            oldPlayer = b.Player;
            b.AddStone(1);

            Assert.Equal(b.GetBoard()[1, 0], oldPlayer + 1);
        }
        [Fact]
        public void VerticalWin()
        {
            var b = new Board();
            for (int i = 1; i <= 4; i++)
            {
                b.AddStone(0);
                b.AddStone(1);
            }
            Assert.True(b.CheckIfPlayerHasWon());
        }
        [Fact]
        public void HorizontalWin()
        {
            var b = new Board();
            b.AddStone(0);
            b.AddStone(0);
            b.AddStone(1);
            b.AddStone(0);
            b.AddStone(2);
            b.AddStone(0);
            b.AddStone(3);
            Assert.True(b.CheckIfPlayerHasWon());
        }

        [Fact]
        public void DiagonalWinLowerLeftToUpperRight()
        {
            var b = new Board();
            b.AddStone(0);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(3);
            b.AddStone(2);
            b.AddStone(3);
            b.AddStone(3);
            b.AddStone(4);
            b.AddStone(3);

            Assert.True(b.CheckIfPlayerHasWon());
        }

        [Fact]
        public void DiagonalWinUpperLeftToLowerRight()
        {
            var b = new Board();
            b.AddStone(4);
            b.AddStone(3);
            b.AddStone(3);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(0);
            b.AddStone(1);

            Assert.True(b.CheckIfPlayerHasWon());
        }
        [Fact]
        public void BoardFull()
        {
            var b = new Board();

            for (byte i = 0; i < 7; i++)
            {
                b.AddStone(i);
                b.AddStone(i);
            }
            Assert.True(b.CheckIfBoardIsFull());
        }
    }
}
