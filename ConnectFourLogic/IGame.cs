﻿namespace ConnectFourLogic
{
    public interface IGame
    {
        IGameBoard GetBoard();

        void DropDisc(int column);
    }
}