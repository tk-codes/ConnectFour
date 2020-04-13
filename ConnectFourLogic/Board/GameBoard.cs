using System;

namespace ConnectFourLogic.Board
{
    public class GameBoard : IGameBoard
    {
        private readonly Player[,] _cells = new Player[7, 6];
        private readonly int _totalDiscsInRowToWin = 4;

        public static int InvalidRowColumn = -1;

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

        public int GetColumnToWin(Player player)
        {
            for (var column = 0; column < GetColumnLength(); column++)
            {
                if (CanPlayerWin(player, column))
                {
                    return column;
                }
            }

            return InvalidRowColumn;
        }

        public bool CanPlayerWin(Player player, int column)
        {
            int nextRow = GetNextAvailableRow(column);
            var currentCell = new BoardCell(column, nextRow);

            return CheckHorizontally(player, currentCell)
                || CheckVertically(player, currentCell)
                || CheckPositiveDiagonal(player, currentCell)
                || CheckNegativeDiagonal(player, currentCell);
        }

        private bool CheckHorizontally(Player player, BoardCell currentCell)
        {
            for (var startColumn = currentCell.Column - 3; startColumn <= currentCell.Column; startColumn++)
            {
                var startCell = new BoardCell(startColumn, currentCell.Row);
                var canConnect = CanConnectFour(player, currentCell, startCell, BoardNavigationHelper.GetNextCellOnRight);

                if (canConnect)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckVertically(Player player, BoardCell currentCell)
        {
            var canConnect = CanConnectFour(player, currentCell, currentCell, BoardNavigationHelper.GetNextCellBelow);

            return canConnect;
        }

        private bool CheckPositiveDiagonal(Player player, BoardCell currentCell)
        {
            for (int startDistance = 3; startDistance >= 0; startDistance--)
            {
                var startCell = new BoardCell(currentCell.Column - startDistance, currentCell.Row + startDistance);
                var canConnect = CanConnectFour(player, currentCell, startCell, BoardNavigationHelper.GetNextCellOnRightCornerAbove);

                if (canConnect)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckNegativeDiagonal(Player player, BoardCell currentCell)
        {
            for (int startDistance = 3; startDistance >= 0; startDistance--)
            {
                var startCell = new BoardCell(currentCell.Column - startDistance, currentCell.Row - startDistance);
                var canConnect = CanConnectFour(player, currentCell, startCell, BoardNavigationHelper.GetNextCellOnRightCornerBelow);

                if (canConnect)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanConnectFour(Player player, BoardCell currentCell, BoardCell startCell, Func<BoardCell, BoardCell> getNextCellFunc)
        {
            BoardCell cellToCheck = startCell;
            var cellToBePlayedNext = isAlreadyPlayed(currentCell) ? null : currentCell;

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

        private bool isAlreadyPlayed(BoardCell cell)
        {
            return IsValidCell(cell) && _cells[cell.Column, cell.Row] != null;
        }

        private bool IsValidCell(BoardCell cell)
        {
            return IsValidCell(cell.Column, cell.Row);
        }

        private bool IsValidCell(int column, int row)
        {
            return column >= 0 && column < GetColumnLength()
                               && row >= 0 && row < GetRowLength();
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
