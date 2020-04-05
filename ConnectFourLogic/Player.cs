using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class Player
    {
        public string Name { get; }

        public string Color { get;  }

        public Player(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
