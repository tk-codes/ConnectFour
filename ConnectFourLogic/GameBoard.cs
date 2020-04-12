using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class GameBoard : IGameBoard
    {
        private readonly Player[,] _cells = new Player[7, 6];
        private readonly int _totalDiscsInRowToWin = 4;

        public static int InvalidRowColumn = -1;

        private readonly Func<BoardCell, BoardCell> _nextHorizontalCellFunc =
            currentCell => new BoardCell(currentCell.Column + 1, currentCell.Row);

        private readonly Func<BoardCell, BoardCell> _nextVerticalCellFunc =
            currentCell => new BoardCell(currentCell.Column, currentCell.Row + 1);

        public int GetColumnLength()
        {
            return _cells.GetLength(0);
        }

        public int GetRowLength()
        {
            return _cells.GetLength(1);
        }

        public string GetDiscColorAtCell(int column, int row)
        {
            var player = _cells[column, row];
            return player?.Color;
        }

        public bool IsFull(int column)
        {
            int nextRow = GetNextAvailableRow(column);
            return nextRow == InvalidRowColumn;
        }

        public int DropDisc(int column, Player player)
        {
            int nextRow = GetNextAvailableRow(column);

            if (nextRow >= 0)
            {
                _cells[column, nextRow] = player;
            }

            return nextRow;
        }

        public bool CanPlayerWin(Player player, int column)
        {
            int nextRow = GetNextAvailableRow(column);
            var currentCell = new BoardCell(column, nextRow);
            return CheckHorizontally(player, currentCell, false)
                || CheckVertically(player, currentCell, false);
        }

        private bool CheckHorizontally(Player player, BoardCell currentCell, bool isAlreadyPlaced = true)
        {
            for (int startColumn = currentCell.Column - 3; startColumn <= currentCell.Column; startColumn++)
            {
                var startCell = new BoardCell(startColumn, currentCell.Row);
                var canConnect = CanConnectFour(player, startCell, _nextHorizontalCellFunc, isAlreadyPlaced ? null : currentCell);

                if (canConnect)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckVertically(Player player, BoardCell currentCell, bool isAlreadyPlaced = true)
        {
            var canConnect = CanConnectFour(player, currentCell, _nextVerticalCellFunc, isAlreadyPlaced ? null : currentCell);

            return canConnect;
        }

        private bool IsValidCell(int column, int row)
        {
            return column >= 0 && column < GetColumnLength()
                               && row >= 0 && row < GetRowLength();
        }

        private bool CanConnectFour(Player player, BoardCell startCell, Func<BoardCell, BoardCell> getNextCellFunc,
            BoardCell? cellToBePlayedNext)
        {
            BoardCell cellToCheck = startCell;
            int count = 0;

            for (int i = 0; i < _totalDiscsInRowToWin; i++)
            {
                if (!IsValidCell(cellToCheck.Column, cellToCheck.Row))
                {
                    return false;
                }

                if (!cellToCheck.Equals(cellToBePlayedNext) &&
                    GetDiscColorAtCell(cellToCheck.Column, cellToCheck.Row) != player.Color)
                {
                    return false;
                }

                count++;
                cellToCheck = getNextCellFunc(cellToCheck);
            }

            return count == _totalDiscsInRowToWin;
        }

        private int GetNextAvailableRow(int column)
        {
            for (int row = GetRowLength() - 1; row >= 0; row--)
            {
                if (_cells[column, row] == null)
                {
                    return row;
                }
            }

            return InvalidRowColumn;
        }
    }
}
