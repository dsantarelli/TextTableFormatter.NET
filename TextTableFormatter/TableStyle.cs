using System;
using System.Collections.Generic;
using System.Text;

namespace TextTableFormatter
{
  internal class TableStyle
  {
    private readonly TableVisibleBorders _shownBorders;
    private readonly bool _escapeXml;
    private readonly string _prompt;

    /// <summary>
    /// Gets the table border style
    /// </summary>
    internal TableBordersStyle BorderStyle { get; private set; }

    internal TableStyle(TableBordersStyle borderStyle, TableVisibleBorders shownBorders, bool escapeXml, int leftMargin, string prompt)
    {
      BorderStyle = borderStyle;
      _shownBorders = shownBorders;
      _escapeXml = escapeXml;
      _prompt = prompt ?? (leftMargin > 0 ? Filler.GetFiller(leftMargin) : string.Empty);
    }

    internal string[] RenderAsStringArray(TextTable table)
    {
      var totalRows = table.Rows.Count;
      Row previousRow = null;
      var allLines = new List<string>();
      for (var i = 0; i < totalRows; i++)
      {
        var row = table.Rows[i];
        var isFirst = i == 0;
        var isSecond = i == 1;
        var isIntermediate = (i > 1 && i < totalRows - 1);
        var isLast = i == (totalRows - 1);
        var rr = RenderRow(row, previousRow, table.Columns, isFirst, isSecond, isIntermediate, isLast);
        foreach (string line in rr) allLines.Add(line);        
        previousRow = row;
      }

      var result = new string[allLines.Count];
      var k = 0;
      foreach (string line in allLines)
      {
        result[k] = line;
        k++;
      }
      return result;
    }

    internal string RenderTable(TextTable table)
    {
      var sb = new StringBuilder();
      var totalRows = table.Rows.Count;
      Row previousRow = null;
      var firstRenderedRow = true;
      for (int i = 0; i < totalRows; i++)
      {
        var r = table.Rows[i];
        var isFirst = i == 0;
        var isSecond = i == 1;
        var isIntermediate = (i > 1 && i < totalRows - 1);
        var isLast = i == (totalRows - 1);
        var rr = RenderRow(r, previousRow, table.Columns, isFirst, isSecond, isIntermediate, isLast);
        foreach (string line in rr)
        {
          if (firstRenderedRow) firstRenderedRow = false;          
          else sb.Append("\n");          
          sb.Append(line);
        }
        previousRow = r;
      }
      return sb.ToString();
    }

    private string EscapeXmlIfRequired(string txt1, string txt2)
    {
      if (!_escapeXml) return txt1 + txt2;
      var sb = new StringBuilder();
      sb.Append(TextEncoder.EscapeXml(txt1));
      sb.Append(TextEncoder.EscapeXml(txt2));
      return sb.ToString();
    }

    private IEnumerable<string> RenderRow(Row row, Row previousRow, IList<Column> columns, bool isFirst, bool isSecond, bool isIntermediate, bool isLast)
    {
      var list = new List<string>();
      if (isFirst)
      {
        if (_shownBorders.IsTopBorderVisible)        
          list.Add(EscapeXmlIfRequired(_prompt, _shownBorders.RenderTopBorder(columns, BorderStyle, row)));        
      }
      else
      {
        if (isIntermediate && _shownBorders.IsMiddleSeparatorVisible || //
            isSecond && _shownBorders.IsHeaderSeparatorVisible //
            || isLast && _shownBorders.IsFooterSeparatorVisible)
        {
          list.Add(EscapeXmlIfRequired(_prompt, _shownBorders.RenderMiddleSeparator(columns, BorderStyle, previousRow, row)));
        }
      }

      list.Add(EscapeXmlIfRequired(_prompt, RenderContentRow(row, columns)));

      if (isLast)
      {
        if (_shownBorders.IsBottomBorderVisible)        
          list.Add(EscapeXmlIfRequired(_prompt, _shownBorders.RenderBottomBorder(columns, BorderStyle, row)));        
      }

      return list;
    }

    private string RenderContentRow(Row row, IList<Column> columns)
    {
      var sb = new StringBuilder();

      // Left border
      if (_shownBorders.IsLeftBorderVisible) sb.Append(BorderStyle.Left);      

      // Cells
      var totalColumns = columns.Count;
      var j = 0;
      foreach (Cell cell in row.Cells)
      {
        // cell separator
        if (j != 0)
        {
          if ((j > 1 && j < totalColumns - 1)
              && _shownBorders.IsCenterSeparatorVisible
              || ((j == 1) && (_shownBorders.IsLeftSeparatorVisible))
              || ((j == (totalColumns - 1)) && (_shownBorders.IsRightSeparatorVisible)))
          {
            sb.Append(BorderStyle.Center);
          }
        }

        // Cell content
        var sepWidth = BorderStyle.Center.Length;
        var width = -sepWidth;
        for (var pos = j; pos < j + cell.ColumnSpan; pos++)        
          width = width + sepWidth + columns[pos].Width;
        
        var renderedCell = cell.Render(width);
        sb.Append(renderedCell);
        j = j + cell.ColumnSpan;
      }

      // Render missing cells
      for (; j < totalColumns; j++)
      {
        // cell separator
        if (j != 0)
        {
          if ((j > 1 && j < totalColumns - 1)
              && _shownBorders.IsCenterSeparatorVisible
              || ((j == 1) && (_shownBorders.IsLeftSeparatorVisible))
              || ((j == (totalColumns - 1)) && (_shownBorders.IsRightSeparatorVisible)))
          {
            sb.Append(BorderStyle.Center);
          }
        }

        // Cell content
        var col = columns[j];
        var renderedCell = CellStyle.RenderNullCell(col.Width);
        sb.Append(renderedCell);
      }

      // Right border
      if (_shownBorders.IsRightBorderVisible)      
        sb.Append(BorderStyle.Right);      

      return sb.ToString();
    }
  }
}
