using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConnectFourLogic.Strategies
{
    class GameStrategyFactory
    {
        public static IGameStrategy Create(GameStrategyLevel level)
        {
            return level switch
            {
                GameStrategyLevel.Easy => new EasyLevelStrategy(),
                _ => throw new NotSupportedException($"Strategy {level} is not supported yet")
            };
        }
    }
}
