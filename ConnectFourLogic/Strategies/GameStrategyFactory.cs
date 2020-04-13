using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ConnectFourLogic.Board;

namespace ConnectFourLogic.Strategies
{
    class GameStrategyFactory
    {
        public static IGameStrategy Create(GameStrategyLevel level, IGameBoard board)
        {
            return level switch
            {
                GameStrategyLevel.Easy => new EasyLevelStrategy(board),
                _ => throw new NotSupportedException($"Strategy {level} is not supported yet")
            };
        }
    }
}
