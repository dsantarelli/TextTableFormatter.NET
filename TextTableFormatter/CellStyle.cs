using System.Text;

namespace TextTableFormatter
{
  /// <summary>
  /// Represents a cell style
  /// </summary>
  public class CellStyle
  {
    private const CellHorizontalAlignment DEFAULT_HORIZONTAL_ALIGN = CellHorizontalAlignment.Left;
    private const CellTextTrimmingStyle DEFAULT_ABBREVIATION_STYLE = CellTextTrimmingStyle.Dots;
    private const CellNullStyle DEFAULT_NULL_STYLE = CellNullStyle.EmptyString;
    private const bool DEFAULT_HANDLE_TERMINAL_FORMATS = true;

    private const string NULL_TEXT = "<null>";
    private const string DOTS_TEXT = "...";
    private const char ESC = (char)27;
    private static readonly string FORMAT_RESET_SEQUENCE = ESC + "[0m";

    private bool _removeTerminalFormats;

    /// <summary>
    /// Gets or sets the cell horizontal alignment
    /// </summary>
    public CellHorizontalAlignment HorizontalAlignment { get; set; }

    /// <summary>
    /// Gets or sets the cell abbreviation style
    /// </summary>
    public CellTextTrimmingStyle TextTrimmingStyle { get; set; }

    /// <summary>
    /// Gets or sets the cell null style
    /// </summary>
    public CellNullStyle NullStyle { get; set; }

    /// <summary>
    /// Initialize a new instance of CellStyle class
    /// </summary>
    public CellStyle()
    {
      Initialize(DEFAULT_HORIZONTAL_ALIGN, DEFAULT_ABBREVIATION_STYLE, DEFAULT_NULL_STYLE, DEFAULT_HANDLE_TERMINAL_FORMATS);
    }

    /// <summary>
    /// Initialize a new instance of CellStyle class
    /// </summary>
    /// <param name="horizontalAlignment">The cell horizontal alignment</param>
    public CellStyle(CellHorizontalAlignment horizontalAlignment)
    {
      Initialize(horizontalAlignment, DEFAULT_ABBREVIATION_STYLE, DEFAULT_NULL_STYLE, DEFAULT_HANDLE_TERMINAL_FORMATS);
    }

    /// <summary>
    /// Initialize a new instance of CellStyle class
    /// </summary>
    /// <param name="horizontalAlignment">The cell horizontal alignment</param>
    /// <param name="textTrimmingStyle">The cell text trimming style</param>
    public CellStyle(CellHorizontalAlignment horizontalAlignment, CellTextTrimmingStyle textTrimmingStyle)
    {
      Initialize(horizontalAlignment, textTrimmingStyle, DEFAULT_NULL_STYLE, DEFAULT_HANDLE_TERMINAL_FORMATS);
    }

    /// <summary>
    /// Initialize a new instance of CellStyle class
    /// </summary>
    /// <param name="horizontalAlignment">The cell horizontal alignment</param>
    /// <param name="textTrimmingStyle">The cell text trimming style</param>
    /// <param name="nullStyle">The cell null style</param>
    public CellStyle(CellHorizontalAlignment horizontalAlignment, CellTextTrimmingStyle textTrimmingStyle, CellNullStyle nullStyle)
    {
      Initialize(horizontalAlignment, textTrimmingStyle, nullStyle, DEFAULT_HANDLE_TERMINAL_FORMATS);
    }

    /// <summary>
    /// Initialize a new instance of CellStyle class
    /// </summary>
    /// <param name="horizontalAlignment">The cell horizontal alignment</param>
    /// <param name="textTrimmingStyle">The cell text trimming style</param>
    /// <param name="nullStyle">The cell null style</param>
    /// <param name="removeTerminalFormats">True: terminal formats will be removed</param>
    public CellStyle(CellHorizontalAlignment horizontalAlignment, CellTextTrimmingStyle textTrimmingStyle, CellNullStyle nullStyle, bool removeTerminalFormats)
    {
      Initialize(horizontalAlignment, textTrimmingStyle, nullStyle, removeTerminalFormats);
    }

    private void Initialize(CellHorizontalAlignment horAlign, CellTextTrimmingStyle textTrimmingStyle, CellNullStyle nullStyle, bool removeTerminalFormats)
    {
      HorizontalAlignment = horAlign;
      TextTrimmingStyle = textTrimmingStyle;
      NullStyle = nullStyle;
      _removeTerminalFormats = removeTerminalFormats;
    }

    internal int GetWidth(string txt)
    {
      string content;
      if (_removeTerminalFormats && txt != null) content = RemoveTerminalFormats(txt);      
      else content = txt;      
      return RenderUncroppedText(content).Length;
    }

    internal string Render(string text, int width)
    {
      var plainText = RenderUncroppedText(text);
      var uc = RenderUnclosedContent(text, width, plainText);
      if (_removeTerminalFormats && (uc.IndexOf("[") != -1)) return uc + FORMAT_RESET_SEQUENCE;      
      return uc;
    }

    private static string RemoveTerminalFormats(string txt)
    {
      var sb = new StringBuilder();
      var i = 0;
      while (i < txt.Length)
      {
        var escIndex = txt.IndexOf(ESC, i);
        if (escIndex == -1)
        {
          sb.Append(txt.Substring(i));
          return sb.ToString();
        }
        var m = txt.IndexOf('m', escIndex);
        if (m == -1) return sb.ToString();
        
        sb.Append(txt.Substring(i, escIndex - i));
        i = m + 1;
      }
      return sb.ToString();
    }

    private string RenderUnclosedContent(string txt, int width, string plainText)
    {
      var tWidth = GetWidth(txt);
      if (tWidth < width)
      {
        switch (HorizontalAlignment)
        {
          case CellHorizontalAlignment.Left: return AlignLeft(plainText, width);
          case CellHorizontalAlignment.Center: return AlignCenter(plainText, width);
          default: return AlignRight(plainText, width);
        }
      }

      if (tWidth == width) return plainText;
      
      switch (TextTrimmingStyle)
      {
        case CellTextTrimmingStyle.Crop: return AbbreviateCrop(plainText, width);
        default: return AbbreviateDots(plainText, width);
      }
    }

    private string AlignLeft(string txt, int width)
    {
      var diff = width - GetWidth(txt);
      return txt + Filler.GetFiller(diff);
    }

    private string AlignCenter(string txt, int width)
    {
      var diff = width - GetWidth(txt);
      var diffLeft = diff / 2;
      var diffRight = diff - diffLeft;
      return Filler.GetFiller(diffLeft) + txt + Filler.GetFiller(diffRight);
    }

    private string AlignRight(string txt, int width)
    {
      var diff = width - GetWidth(txt);
      return Filler.GetFiller(diff) + txt;
    }

    private string AbbreviateCrop(string txt, int width)
    {
      var len = GetLength(txt, width);
      return txt.Substring(0, len);
    }

    private static int GetLength(string txt, int width)
    {
      var added = 0;
      var i = 0;
      while (i < txt.Length && added <= width)
      {
        var c = txt[i];
        if (c == ESC)
        {
          var m = txt.IndexOf('m', i);
          if (m == -1) i = txt.Length;          
          else i = m + 1; 
        }
        else if (added < width)
        {
          i++;
          added++;
        }
        else return i;
      }
      return i;
    }

    private string AbbreviateDots(string txt, int width)
    {
      if (width < 1) return string.Empty;      
      if (width <= DOTS_TEXT.Length) return DOTS_TEXT.Substring(0, width);      
      return AbbreviateCrop(txt, width - DOTS_TEXT.Length) + DOTS_TEXT;
    }

    internal static string RenderNullCell(int width)
    {
      return Filler.GetFiller(width);
    }

    private string RenderUncroppedText(string txt)
    {
      if (txt == null) return CellNullStyle.EmptyString.Equals(NullStyle) ? string.Empty : NULL_TEXT;      
      return txt;
    }
  }
}
