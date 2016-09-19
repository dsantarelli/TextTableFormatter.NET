using System.Collections.Generic;
using System.Text;

namespace TextTableFormatter
{
  /// <summary>
  /// Represents which table borders are visible
  /// </summary>
  public class TableVisibleBorders
  {
    public static TableVisibleBorders NONE = new TableVisibleBorders("..........");
    public static TableVisibleBorders HEADER_ONLY = new TableVisibleBorders("t...t.....");
    public static TableVisibleBorders HEADER_AND_FOOTER = new TableVisibleBorders("t.t.......");
    public static TableVisibleBorders HEADER_FOOTER_AND_COLUMNS = new TableVisibleBorders("t.tttt....");
    public static TableVisibleBorders HEADER_AND_FIRST_COLUMN = new TableVisibleBorders("t..t......");
    public static TableVisibleBorders HEADER_FIRST_AND_LAST_COLUMN = new TableVisibleBorders("t..t.t....");
    public static TableVisibleBorders HEADER_FOOTER_AND_FIRST_COLUMN = new TableVisibleBorders("t.tt......");
    public static TableVisibleBorders HEADER_FOOTER_FIRST_AND_LAST_COLUMN = new TableVisibleBorders("t.tt.t....");
    public static TableVisibleBorders HEADER_AND_COLUMNS = new TableVisibleBorders("t..ttt....");
    public static TableVisibleBorders SURROUND_HEADER_AND_COLUMNS = new TableVisibleBorders("t..ttttttt");
    public static TableVisibleBorders SURROUND_HEADER_FOOTER_AND_COLUMNS = new TableVisibleBorders("t.tttttttt");
    public static TableVisibleBorders SURROUND = new TableVisibleBorders("......tttt");
    public static TableVisibleBorders ALL = new TableVisibleBorders("tttttttttt");

    /// <summary>
    /// Gets or sets if the table bottom border is visible
    /// </summary>
    public bool IsBottomBorderVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table center separator is visible
    /// </summary>
    public bool IsCenterSeparatorVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table footer separator is visible
    /// </summary>
    public bool IsFooterSeparatorVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table header separator is visible
    /// </summary>
    public bool IsHeaderSeparatorVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table left border is visible
    /// </summary>
    public bool IsLeftBorderVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table left separator is visible
    /// </summary>
    public bool IsLeftSeparatorVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table middle separator is visible
    /// </summary>
    public bool IsMiddleSeparatorVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table right border is visible
    /// </summary>
    public bool IsRightBorderVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table right separator is visible
    /// </summary>
    public bool IsRightSeparatorVisible { get; set; }

    /// <summary>
    /// Gets or sets if the table top border is visible
    /// </summary>
    public bool IsTopBorderVisible { get; set; }

    /// <summary>
    /// Initializes a new instance of TableVisibleBorders class
    /// </summary>
    public TableVisibleBorders() { }

    private TableVisibleBorders(string separatorsAndBordersToRender)
    {
      IsHeaderSeparatorVisible = Get(separatorsAndBordersToRender, 0);
      IsMiddleSeparatorVisible = Get(separatorsAndBordersToRender, 1);
      IsFooterSeparatorVisible = Get(separatorsAndBordersToRender, 2);
      IsLeftSeparatorVisible = Get(separatorsAndBordersToRender, 3);
      IsCenterSeparatorVisible = Get(separatorsAndBordersToRender, 4);
      IsRightSeparatorVisible = Get(separatorsAndBordersToRender, 5);
      IsTopBorderVisible = Get(separatorsAndBordersToRender, 6);
      IsBottomBorderVisible = Get(separatorsAndBordersToRender, 7);
      IsLeftBorderVisible = Get(separatorsAndBordersToRender, 8);
      IsRightBorderVisible = Get(separatorsAndBordersToRender, 9);
    }

    internal string RenderTopBorder(IList<Column> columns, TableBordersStyle tiles, Row lowerRow)
    {
      return RenderHorizontalSeparator(columns, tiles.TopLeftCorner,
                                       tiles.TopCenterCorner, tiles.TopRightCorner, tiles.Top, null,
                                       lowerRow, null, tiles.TopCenterCorner, tiles.CenterWidth);
    }
    internal string RenderMiddleSeparator(IList<Column> columns, TableBordersStyle tiles, Row upperRow, Row lowerRow)
    {
      return RenderHorizontalSeparator(columns, tiles.MiddleLeftCorner,
                                       tiles.MiddleCenterCorner, tiles.MiddleRightCorner, tiles.Middle, upperRow,
                                       lowerRow, tiles.UpperColumnSpan, tiles.LowerColumnSpan,
                                       tiles.CenterWidth);
    }
    internal string RenderBottomBorder(IList<Column> columns, TableBordersStyle tiles, Row upperRow)
    {
      return RenderHorizontalSeparator(columns, tiles.BottomLeftCorner,
                                       tiles.BottomCenterCorner, tiles.BottomRightCorner, tiles.Bottom, upperRow,
                                       null, tiles.BottomCenterCorner, null, tiles.CenterWidth);
    }

    private string RenderHorizontalSeparator(IList<Column> columns, string left, string cross, string right, string horizontal, Row upperRow, Row lowerRow, string upperColSpan, string lowerColSpan, int centerWidth)
    {
      var sb = new StringBuilder();

      // Upper Left Corner
      if (IsLeftBorderVisible) sb.Append(left);

      // Cells
      var totalColumns = columns.Count;
      for (var j = 0; j < totalColumns; j++)
      {
        // cell separator
        var upperSep = upperRow != null && upperRow.HasCellSeparatorInPosition(j);
        var lowerSep = lowerRow != null && lowerRow.HasCellSeparatorInPosition(j);

        if (j != 0)
        {
          if ((j > 1 && j < totalColumns - 1) && IsCenterSeparatorVisible
              || ((j == 1) && (IsLeftSeparatorVisible))
              || ((j == (totalColumns - 1)) && (IsRightSeparatorVisible)))
          {
            if (upperSep) sb.Append(lowerSep ? cross : upperColSpan);
            else
            {
              if (lowerSep) sb.Append(lowerColSpan);
              else
              {
                for (var i = 0; i < centerWidth; i++)
                  sb.Append(horizontal);
              }
            }
          }
        }

        // Cell content
        var col = columns[j];
        sb.Append(Filler.GetFiller(horizontal, col.Width));
      }

      // Right border
      if (IsRightBorderVisible) sb.Append(right);
      return sb.ToString();
    }
    private static bool Get(string flags, int index)
    {
      if (flags == null) return false;
      if (index < 0 || index > flags.Length) return false;
      return string.Compare("t", flags.Substring(index, 1), true) == 0;
    }
  }
}
