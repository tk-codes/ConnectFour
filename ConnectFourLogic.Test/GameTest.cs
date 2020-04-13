using FluentAssertions;
using System;
using ConnectFourLogic.Strategies;
using Xunit;

namespace ConnectFourLogic.Test
{
    public class GameTest
    {
        private readonly IGame game;
        private readonly Player playerOne;
        private readonly Player playerTwo;

        public GameTest()
        {
            playerOne = new Player("Player 1", "#fff");
            playerTwo = new Player("Player 2", "#000");
            game = new Game(playerOne, playerTwo, GameStrategyLevel.Easy);
        }
    }
}
