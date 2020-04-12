namespace ConnectFourLogic
{
    public interface IGameBoard
    {
        int GetColumnLength();

        int GetRowLength();

        bool IsFull(int column);

        int DropDisc(int column, Player player);

        string GetDiscColorAtCell(int column, int row);

        bool CanPlayerWin(Player player, int column);
    }
}