using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic.Test
{
    class TestPlayerFactory
    {
        public static Player CreatePlayerOne()
        {
            return new Player("Player 1", "#fff");
        }

        public static Player CreatePlayerTwo()
        {
            return new Player("Player 2", "#000");
        }
    }
}
