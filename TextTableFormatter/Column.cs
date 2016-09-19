using System.Collections.Generic;

namespace TextTableFormatter
{
  internal class Column
  {
    private readonly int _columnIndex;
    private readonly IList<Cell> _cells;
    private int _minWidth;
    private int _maxWidth;

    internal int Width { get; private set; }

    internal Column(int columnIndex, int minWidth, int maxWidth)
    {
      _columnIndex = columnIndex;
      _minWidth = minWidth;
      _maxWidth = maxWidth;
      _cells = new List<Cell>();
      Width = 0;
    }
    internal Column(int columnIndex, int width)
    {
      _columnIndex = columnIndex;
      _minWidth = width;
      _maxWidth = width;
      _cells = new List<Cell>();
      Width = width;
    }

    internal void CalculateWidth(IList<Column> columns, int separatorWidth)
    {
      Width = _minWidth;
      foreach (var cell in _cells)
      {
        var previousWidth = 0;
        if (cell.ColumnSpan > 1)
        {
          for (var pos = _columnIndex - cell.ColumnSpan + 1; pos < _columnIndex; pos++)
            previousWidth = previousWidth + columns[pos].Width + separatorWidth;
        }
        var cellTightWidth = cell.GetTightWidth(_maxWidth);
        var tw = cellTightWidth - previousWidth;
        if (tw > Width) Width = tw;
      }
    }
    internal void AddCell(Cell cell)
    {
      _cells.Add(cell);
    }
    internal void SetWidthRange(int minWidth, int maxWidth)
    {
      _minWidth = minWidth;
      _maxWidth = maxWidth;
    }
  }
}
