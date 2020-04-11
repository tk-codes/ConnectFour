using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class GameBoard : IGameBoard
    {
        private Player[,] cells = new Player[7, 6];

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

        public void DropDisc(int column, Player player)
        {
            int nextRow = GetNextAvailableRow(column);

            if(nextRow >= 0)
            {
                cells[column, nextRow] = player;
            }
        }

        private int GetNextAvailableRow(int column)
        {
            for(int row = GetRowLength() - 1; row >= 0; row--)
            {
                if(cells[column, row] == null)
                {
                    return row;
                }
            }

            return -1;
        }
    }
}
