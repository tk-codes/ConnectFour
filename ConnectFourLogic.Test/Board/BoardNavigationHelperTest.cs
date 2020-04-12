using System;
using System.Collections.Generic;
using System.Text;
using ConnectFourLogic.Board;
using FluentAssertions;
using Xunit;

namespace ConnectFourLogic.Test.Board
{
    public class BoardNavigationHelperTest
    {
        [Fact]
        public void ShouldGetNextCellOnRight()
        {
            var currentCell = new BoardCell(0, 0);
            var expectedNextCell = new BoardCell(1, 0);

            var nextCell = BoardNavigationHelper.GetNextCellOnRight(currentCell);

            nextCell.Should().BeEquivalentTo(expectedNextCell);
        }

        [Fact]
        public void ShouldGetNextCellBelow()
        {
            var currentCell = new BoardCell(0, 4);
            var expectedNextCell = new BoardCell(0, 5);

            var nextCell = BoardNavigationHelper.GetNextCellBelow(currentCell);

            nextCell.Should().BeEquivalentTo(expectedNextCell);
        }

        [Fact]
        public void ShouldGetNextCellOnRightCornerAbove()
        {
            var currentCell = new BoardCell(0, 5);
            var expectedNextCell = new BoardCell(1, 4);

            var nextCell = BoardNavigationHelper.GetNextCellOnRightCornerAbove(currentCell);

            nextCell.Should().BeEquivalentTo(expectedNextCell);
        }

        [Fact]
        public void ShouldGetNextCellOnRightCornerBelow()
        {
            var currentCell = new BoardCell(0, 2);
            var expectedNextCell = new BoardCell(1, 3);

            var nextCell = BoardNavigationHelper.GetNextCellOnRightCornerBelow(currentCell);

            nextCell.Should().BeEquivalentTo(expectedNextCell);
        }
    }
}
