using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class GameBoard : IGameBoard
    {
        private Player[,] cells = new Player[7, 6];
        private readonly int totalDiscsInRowToWin = 4;

        public static int InvalidRowColumn = -1;

        public int GetColumnLength()
        {
            return cells.GetLength(0);
        }

        public int GetRowLength()
        {
            return cells.GetLength(1);
        }

        public string GetDiscColorAtCell(int column, int row)
        {
            var player = cells[column, row];
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
                cells[column, nextRow] = player;
            }

            return nextRow;
        }

        public bool CanPlayerWin(Player player, int column)
        {
            int nextRow = GetNextAvailableRow(column);
            var currentCell = new BoardCell { Column = column, Row = nextRow };
            return CheckHorizontally(player, currentCell, false);
        }

        private bool CheckHorizontally(Player player, BoardCell currentCell, bool isAlreadyPlaced = true)
        {
            // TODO: getStartColumn func
            for (int startColumn = currentCell.Column - 3; startColumn <= currentCell.Column; startColumn++)
            {
                int count = 0;
                for (int i = 0; i < totalDiscsInRowToWin; i++)
                {
                    int columnToCheck = startColumn + i;
                    if(!IsValidCell(columnToCheck, currentCell.Row))
                    {
                        break;
                    }

                    if (!isAlreadyPlaced && currentCell.Column == columnToCheck)
                    {
                        count++;
                        continue;
                    }

                    if (GetDiscColorAtCell(columnToCheck, currentCell.Row) != player.Color)
                    {
                        break;
                    }

                    count++;
                }

                if (count == totalDiscsInRowToWin)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidCell(int column, int row)
        {
            return column >= 0 && column < GetColumnLength()
                               && row >= 0 && row < GetRowLength();
        }

        private bool IsFourInLine(Player player, BoardCell fromCell, BoardCell toCell, Func<int> cellIncFunc)
        {
            return false;
        }

        private int GetNextAvailableRow(int column)
        {
            for (int row = GetRowLength() - 1; row >= 0; row--)
            {
                if (cells[column, row] == null)
                {
                    return row;
                }
            }

            return InvalidRowColumn;
        }
    }
}
