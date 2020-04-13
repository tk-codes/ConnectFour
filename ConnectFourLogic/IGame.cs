using ConnectFourLogic.Board;

namespace ConnectFourLogic
{
    public interface IGame
    {
        IGameBoard GetBoard();

        Player GetCurrentPlayer();

        Player GetWinner();

        bool IsOver();

        void DropDisc(int column);
    }
}