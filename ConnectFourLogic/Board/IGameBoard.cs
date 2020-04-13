namespace ConnectFourLogic.Board
{
    public interface IGameBoard
    {
        int GetColumnLength();

        int GetRowLength();

        bool IsFull(int column);

        int DropDisc(int column, Player player);

        string GetDiscColorAtCell(int column, int row);

        int GetColumnToWin(Player player);

        bool CanPlayerWin(Player player, int column);
    }
}