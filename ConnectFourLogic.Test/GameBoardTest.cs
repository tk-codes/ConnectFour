﻿using FluentAssertions;
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

        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(0, 1, 3, 2)]
        [InlineData(0, 2, 3, 1)]
        [InlineData(1, 2, 3, 0)]
        public void CanWinHorizontally(int first, int second, int third, int columnToDrop)
        {
            board.DropDisc(first, playerOne);
            board.DropDisc(second, playerOne);
            board.DropDisc(third, playerOne);

            var canWin = board.CanPlayerWin(playerOne, columnToDrop);

            canWin.Should().BeTrue();
        }

        [Fact]
        public void CanNotWinHorizontally()
        {
            board.DropDisc(0, playerOne);
            board.DropDisc(1, playerOne);
            board.DropDisc(2, playerTwo);

            var canWin = board.CanPlayerWin(playerOne, 3);

            canWin.Should().BeFalse();
        }
    }
}
