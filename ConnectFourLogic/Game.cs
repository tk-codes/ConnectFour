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

        private GameBoard board { get; }

        public Game(Player playerOne, Player playerTwo, GameStrategyLevel level)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            this.level = level;
            CurrentPlayer = PlayerOne;

            board = new GameBoard();
        }

        public int GetColumnLength()
        {
            return board.Cells.GetLength(0);
        }

        public int GetRowLength()
        {
            return board.Cells.GetLength(1);
        }

        public string GetDiscColorAtCell(int column, int row)
        {
            var player = board.Cells[column, row];
            return player?.Color;
        }

        public void DropDisc(int column)
        {
            board.Cells[column, 0] = CurrentPlayer;
        }
    }
}
