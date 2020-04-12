using ConnectFourLogic.Strategies;
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

        private IGameStrategy strategy;

        private IGameBoard board { get; }

        public Game(Player playerOne, Player playerTwo, GameStrategyLevel level)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            CurrentPlayer = PlayerOne;

            board = new GameBoard();
            strategy = GameStrategyFactory.Create(level);
        }

        public IGameBoard GetBoard()
        {
            return board;
        }

        public void DropDisc(int column)
        {
            int droppedRow = board.DropDisc(column, CurrentPlayer);

            // TODO: check if the current player has won
            SwitchPlayer();
            
            (int playedColumn, int playedRow) = strategy.Play(CurrentPlayer);
            // TODO: check if the switched player has won
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == PlayerTwo ? PlayerOne : PlayerTwo;
        }
    }
}
