using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class Game
    {
        public Player CurrentPlayer { get; private set; }

        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        private GameStrategyLevel level { get; }

        public Game(Player playerOne, Player playerTwo, GameStrategyLevel level)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            this.level = level;
            CurrentPlayer = PlayerOne;
        }
    }
}
