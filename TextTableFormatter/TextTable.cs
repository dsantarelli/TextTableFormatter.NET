using System;
using System.Collections.Generic;

namespace TextTableFormatter
{
  /// <summary>
  /// Represents the text table
  /// </summary>
  public class TextTable
  {
    private const int DEFAULT_MIN_WIDTH = 0;
    private const int DEFAULT_MAX_WIDTH = int.MaxValue;
    private readonly TableStyle _tableStyle;
    private int _currentColumn;
    private Row _currentRow;
    private int _totalColumns;

    internal IList<Row> Rows { get; private set; }
    internal IList<Column> Columns { get; private set; }

    /// <summary>
    /// Initializes a new instance of TextTable class
    /// </summary>
    /// <param name="columnsCount">The columns count</param>
    public TextTable(int columnsCount)
    {
      Initialize(columnsCount);
      _tableStyle = new TableStyle(TableBordersStyle.CLASSIC, TableVisibleBorders.SURROUND_HEADER_AND_COLUMNS, false, 0, null);
    }

    /// <summary>
    /// Initializes a new instance of TextTable class
    /// </summary>
    /// <param name="columnsCount">The columns count</param>
    /// <param name="borderStyle">The table border style</param>
    public TextTable(int columnsCount, TableBordersStyle borderStyle)
    {
      Initialize(columnsCount);
      _tableStyle = new TableStyle(borderStyle, TableVisibleBorders.SURROUND_HEADER_AND_COLUMNS, false, 0, null);
    }

    /// <summary>
    /// Initializes a new instance of TextTable class
    /// </summary>
    /// <param name="columnsCount">The columns count</param>
    /// <param name="borderStyle">The table border style</param>
    /// <param name="visibleBorders">The table visible borders</param>
    public TextTable(int columnsCount, TableBordersStyle borderStyle, TableVisibleBorders visibleBorders)
    {
      Initialize(columnsCount);
      _tableStyle = new TableStyle(borderStyle, visibleBorders, false, 0, null);
    }

    /// <summary>
    /// Initializes a new instance of TextTable class
    /// </summary>
    /// <param name="columnsCount">The columns count</param>
    /// <param name="borderStyle">The table border style</param>
    /// <param name="visibleBorders">The table visible borders</param>
    /// <param name="escapeXml">true if xml content must be escaped</param>
    public TextTable(int columnsCount, TableBordersStyle borderStyle, TableVisibleBorders visibleBorders, bool escapeXml)
    {
      Initialize(columnsCount);
      _tableStyle = new TableStyle(borderStyle, visibleBorders, escapeXml, 0, null);
    }

    /// <summary>
    /// Initializes a new instance of TextTable class
    /// </summary>
    /// <param name="columnsCount">The columns count</param>
    /// <param name="borderStyle">The table border style</param>
    /// <param name="visibleBorders">The table visible borders</param>
    /// <param name="escapeXml">true if xml content must be escaped</param>
    /// <param name="leftMargin">The table left margin</param>
    public TextTable(int columnsCount, TableBordersStyle borderStyle, TableVisibleBorders visibleBorders, bool escapeXml, int leftMargin)
    {
      Initialize(columnsCount);
      _tableStyle = new TableStyle(borderStyle, visibleBorders, escapeXml, leftMargin, null);
    }

    /// <summary>
    /// Initializes a new instance of TextTable class
    /// </summary>
    /// <param name="columnsCount">The columns count</param>
    /// <param name="borderStyle">The table border style</param>
    /// <param name="visibleBorders">The table visible borders</param>
    /// <param name="escapeXml">true if xml content must be escaped</param>
    /// <param name="prompt">The table prompt string</param>
    public TextTable(int columnsCount, TableBordersStyle borderStyle, TableVisibleBorders visibleBorders, bool escapeXml, string prompt)
    {
      Initialize(columnsCount);
      _tableStyle = new TableStyle(borderStyle, visibleBorders, escapeXml, 0, prompt);
    }

    /// <summary>
    /// Adds a cell with the given content
    /// </summary>
    /// <param name="content">The cell content</param>
    public void AddCell(string content)
    {
      AddCell(content, new CellStyle());
    }

    /// <summary>
    /// Adds a cell with the given content and column span
    /// </summary>
    /// <param name="content">The cell content</param>
    /// <param name="columnSpan">The cell column span</param>
    public void AddCell(string content, int columnSpan)
    {
      AddCell(content, new CellStyle(), columnSpan);
    }

    /// <summary>
    /// Adds a cell with a given content, a style and a column span.
    /// The cell will be arranged in a new row if necessary
    /// </summary>
    /// <param name="content">The cell content</param>
    /// <param name="style">The cell style</param>
    /// <param name="columnSpan">The cell column span</param>
    public void AddCell(string content, CellStyle style, int columnSpan = 1)
    {
      if (columnSpan < 1) throw new ArgumentException("columnSpan must be greater or equal to 0");

      if (_currentRow == null || _currentColumn >= _totalColumns)
      {
        _currentRow = new Row();
        Rows.Add(_currentRow);
        _currentColumn = 0;
      }
      int adjColSpan = columnSpan > 0 ? columnSpan : 1;
      if (_currentColumn + adjColSpan > _totalColumns)
      {
        adjColSpan = _totalColumns - _currentColumn;
      }
      _currentRow.Cells.Add(new Cell(content, style, adjColSpan));
      _currentColumn = _currentColumn + adjColSpan;
    }

    /// <summary>
    /// Gets the cell corresponding to the given row index and column index
    /// </summary>
    /// <param name="rowIndex">The table row index</param>
    /// <param name="columnIndex">The table column index</param>
    /// <returns></returns>
    internal Cell GetCell(int rowIndex, int columnIndex)
    {
      return Rows[rowIndex].Cells[columnIndex];
    }

    /// <summary>
    /// Sets the column width range (min - max)
    /// </summary>
    /// <param name="columnIndex">The column index</param>
    /// <param name="minWidth">The column min width</param>
    /// <param name="maxWidth">The column max width</param>
    public void SetColumnWidthRange(int columnIndex, int minWidth, int maxWidth)
    {
      Columns[columnIndex].SetWidthRange(minWidth, maxWidth);
    }

    /// <summary>
    /// Renders the table as a string
    /// </summary>
    /// <returns></returns>
    public string Render()
    {
      CalculateColumnsWidth();
      return _tableStyle.RenderTable(this);
    }

    /// <summary>
    /// Renders the table as a string array (each array element is a row)
    /// </summary>
    /// <returns></returns>
    public string[] RenderAsStringArray()
    {
      CalculateColumnsWidth();
      return _tableStyle.RenderAsStringArray(this);
    }

    private void Initialize(int totalColumns)
    {
      _totalColumns = totalColumns;
      Rows = new List<Row>();
      var columns = new List<Column>();

      for (var i = 0; i < _totalColumns; i++)      
        columns.Add(new Column(i, DEFAULT_MIN_WIDTH, DEFAULT_MAX_WIDTH));
      
      Columns = columns.ToArray();
      _currentColumn = 0;
      _currentRow = null;
    }

    private void CalculateColumnsWidth()
    {
      // First we connect the columns with the cells.
      foreach (var row in Rows)
      {
        var startCol = 0;
        foreach (var cell in row.Cells)
        {
          var endCol = startCol + cell.ColumnSpan - 1;
          try
          {
            var col = Columns[endCol];
            col.AddCell(cell);
            startCol = startCol + cell.ColumnSpan;
          }
          catch (IndexOutOfRangeException)
          {
            // Nothing to do.
          }
        }
      }

      // Then we calculate the appropriate column width for each one.
      foreach (var col in Columns)
        col.CalculateWidth(Columns, _tableStyle.BorderStyle.TopCenterCorner.Length);      
    }
  }
}
