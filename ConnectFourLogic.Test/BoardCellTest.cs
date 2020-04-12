using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace ConnectFourLogic.Test
{
    public class BoardCellTest
    {
        [Fact]
        public void ShouldBeEqual()
        {
            var cell1 = new BoardCell(0, 0);
            var cell2 = new BoardCell(0, 0);

            var result = cell1.Equals(cell2);

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotBeEqual()
        {
            var cell1 = new BoardCell(0, 1);
            var cell2 = new BoardCell(0, 0);

            var result = cell1.Equals(cell2);

            result.Should().BeFalse();
        }
    }
}
