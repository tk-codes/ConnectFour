using ConnectFourLogic.Strategies;
using System;
using System.Collections.Generic;
using System.Text;
using ConnectFourLogic.Board;

namespace ConnectFourLogic
{
    public class Game : IGame
    {
        public Player CurrentPlayer { get; private set; }

        public bool IsOver { get; private set; }

        public Player Winner { get; private set; }

        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        private readonly IGameStrategy _strategy;

        private readonly IGameBoard _board;

        public Game(Player playerOne, Player playerTwo, GameStrategyLevel level)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            CurrentPlayer = PlayerOne;

            _board = new GameBoard();
            _strategy = GameStrategyFactory.Create(level, _board);
        }

        public IGameBoard GetBoard()
        {
            return _board;
        }

        public void DropDisc(int column)
        {
            if (IsOver)
            {
                return;
            }

            int droppedRow = _board.DropDisc(column, CurrentPlayer);
            if (droppedRow == GameBoard.InvalidRowColumn)
            {
                return;
            }

            // TODO: check if the current player has won
            SwitchPlayer();
            
            (int playedColumn, int playedRow) = _strategy.Play(CurrentPlayer, GetOpponent());
            // TODO: check if the switched player has won
            SwitchPlayer();
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == PlayerTwo ? PlayerOne : PlayerTwo;
        }

        private Player GetOpponent()
        {
            return CurrentPlayer == PlayerTwo ? PlayerOne : PlayerTwo;
        }
    }
}
