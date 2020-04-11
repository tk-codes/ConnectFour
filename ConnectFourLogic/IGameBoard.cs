﻿namespace ConnectFourLogic
{
    public interface IGameBoard
    {
        int GetColumnLength();

        int GetRowLength();

        bool IsFull(int column);

        void DropDisc(int column, Player player);

        string GetDiscColorAtCell(int column, int row);
    }
}