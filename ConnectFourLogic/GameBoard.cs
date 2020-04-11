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

        }

        private int GetNextAvailableRow(int column)
        {
            return -1;
        }
    }
}
