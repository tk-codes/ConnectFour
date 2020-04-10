namespace ConnectFourLogic
{
    public interface IGame
    {
        int GetColumnLength();

        int GetRowLength();

        string GetDiscColorAtCell(int column, int row);

        void DropDisc(int column);
    }
}