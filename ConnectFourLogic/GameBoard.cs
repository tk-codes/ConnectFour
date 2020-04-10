using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class GameBoard
    {
        public Player[,] Cells { get; } = new Player[6, 7];
    }
}
