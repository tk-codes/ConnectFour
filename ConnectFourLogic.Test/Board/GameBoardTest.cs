using System.Linq;
using ConnectFourLogic.Board;
using FluentAssertions;
using Xunit;

namespace ConnectFourLogic.Test.Board
{
    public class GameBoardTest
    {
        private readonly IGameBoard _board;
        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        public GameBoardTest()
        {
            _board = new GameBoard();
            _playerOne = TestPlayerFactory.CreatePlayerOne();
            _playerTwo = TestPlayerFactory.CreatePlayerTwo();
        }

        [Fact]
        public void ShouldGetColumnLength()
        {
            _board.GetColumnLength().Should().Be(7);
        }

        [Fact]
        public void ShouldGetRowLength()
        {
            _board.GetRowLength().Should().Be(6);
        }

        [Fact]
        public void ShouldNotBeFull()
        {
            _board.IsFull(2).Should().BeFalse();
        }

        [Fact]
        public void ShouldDropDiscInTheLastRow()
        {
            _board.DropDisc(2, _playerOne);

            _board.GetDiscColorAtCell(2, 5).Should().Be(_playerOne.Color);
        }

        [Fact]
        public void ShouldDropDiscInTheSecondLastRow()
        {
            _board.DropDisc(2, _playerOne);
            _board.DropDisc(2, _playerOne);

            _board.GetDiscColorAtCell(2, 4).Should().Be(_playerOne.Color);
        }

        [Fact]
        public void ShouldNotDropDiscWhenFull()
        {
            _board.DropDisc(2, _playerOne);
            _board.DropDisc(2, _playerOne);
            _board.DropDisc(2, _playerOne);
            _board.DropDisc(2, _playerOne);
            _board.DropDisc(2, _playerOne);
            _board.DropDisc(2, _playerOne);

            _board.DropDisc(2, _playerTwo);

            _board.IsFull(2).Should().BeTrue();
            _board.GetDiscColorAtCell(2, 0).Should().Be(_playerOne.Color);
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(0, 1, 3, 2)]
        [InlineData(0, 2, 3, 1)]
        [InlineData(1, 2, 3, 0)]
        public void CanWinHorizontally(int first, int second, int third, int columnToDrop)
        {
            _board.DropDisc(first, _playerOne);
            _board.DropDisc(second, _playerOne);
            _board.DropDisc(third, _playerOne);

            var canWin = _board.CanPlayerWin(_playerOne, columnToDrop);

            canWin.Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(0, 1, 3, 2)]
        [InlineData(0, 2, 3, 1)]
        [InlineData(1, 2, 3, 0)]
        [InlineData(1, 2, 3, null)]
        public void CanNotWinHorizontally(int first, int second, int third, int? opponent)
        {
            if(opponent.HasValue)
            {
                _board.DropDisc(opponent.Value, _playerTwo);
            }
            
            _board.DropDisc(first, _playerOne);
            _board.DropDisc(second, _playerOne);

            var canWin = _board.CanPlayerWin(_playerOne, third);

            canWin.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CanWinVertically(int column)
        {
            _board.DropDisc(column, _playerOne);
            _board.DropDisc(column, _playerOne);
            _board.DropDisc(column, _playerOne);

            var canWin = _board.CanPlayerWin(_playerOne, column);

            canWin.Should().BeTrue();
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(2, null)]
        public void CanNotWinVertically(int totalDroppedDiscs, int? opponent)
        {
            int column = 0;

            for (int i = 0; i < totalDroppedDiscs; i++)
            {
                _board.DropDisc(column, i == opponent ? _playerTwo : _playerOne);
            }

            var canWin = _board.CanPlayerWin(_playerOne, column);

            canWin.Should().BeFalse();
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(1, 2, 4, 3)]
        [InlineData(1, 3, 4, 2)]
        [InlineData(2, 3, 4, 1)]
        public void CanWinPositiveDiagonally(int first, int second, int third, int winningColumn)
        {
            FillInColumn(first, first, _playerTwo);
            _board.DropDisc(first, _playerOne);

            FillInColumn(second, second, _playerTwo);
            _board.DropDisc(second, _playerOne);

            FillInColumn(third, third, _playerTwo);
            _board.DropDisc(third, _playerOne);

            FillInColumn(winningColumn, winningColumn, _playerTwo);

            var canWin = _board.CanPlayerWin(_playerOne, winningColumn);

            canWin.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 2, 3, 0)]
        [InlineData(2, 3, 4, 1)]
        [InlineData(1, 4, 3, 2)]
        [InlineData(1, 4, 2, 3)]
        [InlineData(2, 3, 1, 4)]
        [InlineData(3, 4, 1, null)]
        public void CanNotWinPositiveDiagonally(int first, int second, int third, int? opponent)
        {
            FillInColumn(first, first, _playerTwo);
            _board.DropDisc(first, _playerOne);

            FillInColumn(second, second, _playerTwo);
            _board.DropDisc(second, _playerOne);

            if (opponent.HasValue)
            {
                FillInColumn(opponent.Value, opponent.Value + 1, _playerTwo);
            }

            FillInColumn(third, third, _playerTwo);

            var canWin = _board.CanPlayerWin(_playerOne, third);

            canWin.Should().BeFalse();
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(1, 2, 3, 4)]
        [InlineData(1, 2, 4, 3)]
        [InlineData(1, 3, 4, 2)]
        [InlineData(2, 3, 4, 1)]
        public void CanWinNegativeDiagonally(int first, int second, int third, int winningColumn)
        {
            const int totalDicsInFirstColumn = 4;

            FillInColumn(first, totalDicsInFirstColumn - first, _playerTwo);
            _board.DropDisc(first, _playerOne);

            FillInColumn(second, totalDicsInFirstColumn - second, _playerTwo);
            _board.DropDisc(second, _playerOne);

            FillInColumn(third, totalDicsInFirstColumn - third, _playerTwo);
            _board.DropDisc(third, _playerOne);

            FillInColumn(winningColumn, totalDicsInFirstColumn - winningColumn, _playerTwo);

            var canWin = _board.CanPlayerWin(_playerOne, winningColumn);

            canWin.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 2, 3, 0)]
        [InlineData(2, 3, 4, 1)]
        [InlineData(1, 4, 3, 2)]
        [InlineData(1, 4, 2, 3)]
        [InlineData(2, 3, 1, 4)]
        [InlineData(3, 4, 1, null)]
        public void CanNotWinNegativeDiagonally(int first, int second, int third, int? opponent)
        {
            const int totalDicsInFirstColumn = 4;

            FillInColumn(first, totalDicsInFirstColumn - first, _playerTwo);
            _board.DropDisc(first, _playerOne);

            FillInColumn(second, totalDicsInFirstColumn - second, _playerTwo);
            _board.DropDisc(second, _playerOne);

            if (opponent.HasValue)
            {
                FillInColumn(opponent.Value, totalDicsInFirstColumn - opponent.Value + 1, _playerTwo);
            }

            FillInColumn(third, totalDicsInFirstColumn - third, _playerTwo);

            var canWin = _board.CanPlayerWin(_playerOne, third);

            canWin.Should().BeFalse();
        }

        private void FillInColumn(int column, int totalRows, Player player)
        {
            foreach(int unused in Enumerable.Range(0, totalRows))
            {
                _board.DropDisc(column, player);
            }
        }
    }
}
