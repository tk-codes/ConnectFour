using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourLogic
{
    public class BoardCell
    {
        public int Column { get; }

        public int Row { get; }

        public BoardCell(int column, int row)
        {
            Column = column;
            Row = row;
        }


        public override bool Equals(object obj)
        {
            var item = obj as BoardCell;

            if (item == null)
            {
                return false;
            }

            return Column == item.Column && Row == item.Row;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Column * 397) ^ Row;
            }
        }
    }
}
