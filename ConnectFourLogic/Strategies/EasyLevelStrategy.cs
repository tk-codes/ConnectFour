using System;
using System.Collections.Generic;
using System.Text;
using ConnectFourLogic.Board;

namespace ConnectFourLogic.Strategies
{
    class EasyLevelStrategy : IGameStrategy
    {
        private readonly IGameBoard _board;

        public EasyLevelStrategy(IGameBoard board)
        {
            _board = board;
        }

        public GameStrategyLevel GetLevel()
        {
            return GameStrategyLevel.Easy;
        }

        public (int, int) Play(Player currentPlayer, Player opponentPlayer)
        {
            var column = _board.GetColumnToWin(currentPlayer);
            if (column >= 0)
            {
                var row = _board.DropDisc(column, currentPlayer);
                return (column, row);
            }

            column = _board.GetColumnToWin(opponentPlayer);
            // TODO: Refactor repeating if-block code
            if (column >= 0)
            {
                var row = _board.DropDisc(column, currentPlayer);
                return (column, row);
            }

            // TODO: Check if column is already full
            column = GetRandomColumn();
            if (column >= 0)
            {
                var row = _board.DropDisc(column, currentPlayer);
                return (column, row);
            }

            return (column, GameBoard.InvalidRowColumn);
        }

        private int GetRandomColumn()
        {
            var random = new Random();
            return random.Next(0, 7);
        }
    }
}
