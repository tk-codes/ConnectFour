using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic.Strategies
{
    class EasyLevelStrategy : IGameStrategy
    {
        public (int, int) Play(Player currentPlayer)
        {
            // can I win --> drop disc to win
            // can the opponent win --> drop disc to block
            // drop disc at random column
            return (GameBoard.InvalidRowColumn, GameBoard.InvalidRowColumn);
        }
    }
}
