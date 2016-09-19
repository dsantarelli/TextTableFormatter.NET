using System.Collections.Generic;

namespace TextTableFormatter
{
  internal class Row
  {
    internal IList<Cell> Cells { get; }

    internal Row()
    {
      Cells = new List<Cell>();
    }

    internal bool HasCellSeparatorInPosition(int position)
    {
      if (position == 0) return true;
      var i = 0;
      foreach (var cell in Cells)
      {
        if (i < position)
        {
          if (i + cell.ColumnSpan > position) return false;
        }
        else return true;

        i = i + cell.ColumnSpan;
      }
      return true;
    }
  }
}
