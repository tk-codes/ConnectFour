using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConnectFourLogic.Test
{
    public class GameBoardTest
    {
        private readonly IGameBoard board;
        private readonly Player playerOne;
        private readonly Player playerTwo;

        public GameBoardTest()
        {
            board = new GameBoard();
            playerOne = TestPlayerFactory.CreatePlayerOne();
            playerTwo = TestPlayerFactory.CreatePlayerTwo();
        }

        [Fact]
        public void ShouldGetColumnLength()
        {
            board.GetColumnLength().Should().Be(7);
        }

        [Fact]
        public void ShouldGetRowLength()
        {
            board.GetRowLength().Should().Be(6);
        }

        [Fact]
        public void ShouldNotBeFull()
        {
            board.IsFull(2).Should().BeFalse();
        }

        [Fact]
        public void ShouldDropDiscInTheLastRow()
        {
            board.DropDisc(2, playerOne);

            board.GetDiscColorAtCell(2, 5).Should().Be(playerOne.Color);
        }

        [Fact]
        public void ShouldDropDiscInTheSecondLastRow()
        {
            board.DropDisc(2, playerOne);
            board.DropDisc(2, playerOne);

            board.GetDiscColorAtCell(2, 4).Should().Be(playerOne.Color);
        }

        [Fact]
        public void ShouldNotDropDiscWhenFull()
        {
            board.DropDisc(2, playerOne);
            board.DropDisc(2, playerOne);
            board.DropDisc(2, playerOne);
            board.DropDisc(2, playerOne);
            board.DropDisc(2, playerOne);
            board.DropDisc(2, playerOne);

            board.DropDisc(2, playerTwo);

            board.IsFull(2).Should().BeTrue();
            board.GetDiscColorAtCell(2, 0).Should().Be(playerOne.Color);
        }
    }
}
