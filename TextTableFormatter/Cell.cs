
namespace TextTableFormatter
{
  /// <summary>
  /// Represents a table cell
  /// </summary>
  internal class Cell
  {
    /// <summary>
    /// Gets the cell content
    /// </summary>
    internal string Content { get; private set; }

    /// <summary>
    /// Gets the cell style
    /// </summary>
    internal CellStyle Style { get; private set; }

    /// <summary>
    /// Gets the cell column span
    /// </summary>
    internal int ColumnSpan { get; private set; }

    internal Cell() : this(string.Empty, new CellStyle()) { }
    internal Cell(string content) : this(content, new CellStyle()) { }
    internal Cell(string content, CellStyle style, int columnSpan = 1)
    {
      Content = content;
      Style = style;
      ColumnSpan = columnSpan;
    }

    internal int GetTightWidth(int maxWidth)
    {
      var width = Style.GetWidth(Content);
      return width > maxWidth ? maxWidth : width;
    }

    internal string Render(int width)
    {
      return Style.Render(Content, width);
    }
  }
}
