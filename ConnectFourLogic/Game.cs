using ConnectFourLogic.Strategies;
using System;
using System.Collections.Generic;
using System.Text;
using ConnectFourLogic.Board;

namespace ConnectFourLogic
{
    public class Game : IGame
    {
        private bool _isOver;

        private Player _currentPlayer;

        private readonly Player _playerOne;
        private readonly Player _playerTwo;

        private Player _winner;

        private readonly IGameStrategy _strategy;

        private readonly IGameBoard _board;

        public Game(Player playerOne, Player playerTwo, GameStrategyLevel level)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _currentPlayer = _playerOne;

            _board = new GameBoard();
            _strategy = GameStrategyFactory.Create(level, _board);
        }

        public IGameBoard GetBoard()
        {
            return _board;
        }

        public bool IsOver()
        {
            return _isOver;
        }
        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public Player GetWinner()
        {
            return _winner;
        }

        public void DropDisc(int column)
        {
            if (_isOver)
            {
                return;
            }

            int droppedRow = _board.DropDisc(column, _currentPlayer);
            if (droppedRow == GameBoard.InvalidRowColumn)
            {
                return;
            }

            CheckGameStatus(column, droppedRow);
            if (_isOver)
            {
                return;
            }

            SwitchPlayer();

            if (_strategy.GetLevel() != GameStrategyLevel.MultiPlayer)
            {
                (int playedColumn, int playedRow) = _strategy.Play(_currentPlayer, GetOpponent());
                CheckGameStatus(playedColumn, playedRow);

                SwitchPlayer();
            }
        }

        private void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == _playerTwo ? _playerOne : _playerTwo;
        }

        private Player GetOpponent()
        {
            return _currentPlayer == _playerTwo ? _playerOne : _playerTwo;
        }

        private void CheckGameStatus(int column, int row)
        {
            var hasWon = _board.HasPlayerWon(_currentPlayer, new BoardCell(column, row));

            if (hasWon)
            {
                _isOver = true;
                _winner = _currentPlayer;
                return;
            }

            if (_board.IsFull())
            {
                _isOver = true;
            }
        }
    }
}
