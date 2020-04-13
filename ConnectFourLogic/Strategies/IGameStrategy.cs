using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic.Strategies
{
    public interface IGameStrategy
    {
        (int, int) Play(Player currentPlayer, Player opponentPlayer);
    }
}
