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
        private readonly Player player;

        public GameBoardTest()
        {
            board = new GameBoard();
            player = TestPlayerFactory.CreatePlayerOne();
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
        public void ShouldDropDiscInTheLastRow()
        {
            board.DropDisc(2, player);

            board.GetDiscColorAtCell(2, 6).Should().Be(player.Color);
        }
    }
}
