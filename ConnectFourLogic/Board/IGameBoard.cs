﻿using System.Collections;
using System.Collections.Generic;

namespace ConnectFourLogic.Board
{
    public interface IGameBoard
    {
        int GetColumnLength();

        int GetRowLength();

        IEnumerable<int> ColumnIndices();

        bool IsFull();

        bool IsColumnFull(int column);

        int DropDisc(int column, Player player);

        string GetDiscColorAtCell(int column, int row);

        int GetColumnToWin(Player player);

        bool CanPlayerWin(Player player, int column);

        bool HasPlayerWon(Player player, BoardCell lastPlayedCell);
    }
}