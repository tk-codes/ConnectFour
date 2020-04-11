using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class Game : IGame
    {
        public Player CurrentPlayer { get; private set; }

        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        private GameStrategyLevel level { get; }

        private IGameBoard board { get; }

        public Game(Player playerOne, Player playerTwo, GameStrategyLevel level)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            this.level = level;
            CurrentPlayer = PlayerOne;

            board = new GameBoard();
        }

        public IGameBoard GetBoard()
        {
            return board;
        }

        public void DropDisc(int column)
        {
            board.DropDisc(column, CurrentPlayer);
        }
    }
}
