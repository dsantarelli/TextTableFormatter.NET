
using System;

namespace TextTableFormatter
{
  /// <summary>
  /// Represents a table borders style
  /// </summary>
  public class TableBordersStyle
  {
    public static TableBordersStyle DEMO = new TableBordersStyle("1a234b567c89xyztu");
    public static TableBordersStyle BLANKS = new TableBordersStyle("    " + "    " + "    " + "   " + "  ");
    public static TableBordersStyle DOTS = new TableBordersStyle("...." + "...." + "...." + "..." + "..");
    public static TableBordersStyle ASTERISKS = new TableBordersStyle("****" + "****" + "****" + "***" + "**");
    public static TableBordersStyle HORIZONTAL_ONLY = new TableBordersStyle("", "-", " ", "", "", "-", " ", "", "", "-", " ", "", "", " ", "", " ", " ");
    public static TableBordersStyle CLASSIC = new TableBordersStyle("+-++" + "+-++" + "+-++" + "|||" + "--");
    public static TableBordersStyle CLASSIC_WIDE = new TableBordersStyle("+-", "-", "-+-", "-+", "+-", "-", "-+-", "-+", "+-", "-", "-+-", "-+", "| ", " | ", " |", "---", "---");
    public static TableBordersStyle CLASSIC_LIGHT = new TableBordersStyle("+--+" + "+--+" + "+--+" + "| |" + "--");
    public static TableBordersStyle CLASSIC_LIGHT_WIDE = new TableBordersStyle("+-", "-", "--", "-+", "+-", "-", "--", "-+", "+-", "-", "--", "-+", "| ", "  ", " |", "--", "--");
    public static TableBordersStyle CLASSIC_COMPATIBLE = new TableBordersStyle("+-++" + "+-++" + "+-++" + "!!!" + "--");
    public static TableBordersStyle CLASSIC_COMPATIBLE_WIDE = new TableBordersStyle("+-", "-", "-+-", "-+", "+-", "-", "-+-", "-+", "+-", "-", "-+-", "-+", "! ", " ! ", " !", "---", "---");
    public static TableBordersStyle CLASSIC_COMPATIBLE_LIGHT_WIDE = new TableBordersStyle("+-", "-", "--", "-+", "+-", "-", "--", "-+", "+-", "-", "--", "-+", "! ", "  ", " !", "--", "--");
    public static TableBordersStyle HEAVY = new TableBordersStyle("+==+" + "+==+" + "+==+" + "|||" + "==");
    public static TableBordersStyle HEAVY_TOP_AND_BOTTOM = new TableBordersStyle("+==+" + "+--+" + "+==+" + "|||" + "--");
    public static TableBordersStyle DESIGN_FORMAL = new TableBordersStyle("", "=", "=", "", "", "-", " ", "", "", "=", "=", "", "", " ", "", " ", " ");
    public static TableBordersStyle DESIGN_FORMAL_INVERSE = new TableBordersStyle("", "-", "-", "", "", "=", " ", "", "", "-", "-", "", "", " ", "", " ", " ");
    public static TableBordersStyle DESIGN_CASUAL = new TableBordersStyle("", "=", "=", "", "", "~", " ", "", "", "=", "=", "", "", " ", "", " ", " ");
    public static TableBordersStyle DESIGN_CAFE = new TableBordersStyle("", "~", "~", "", "", "~", " ", "", "", "~", "~", "", "", " ", "", " ", " ");
    public static TableBordersStyle DESIGN_SLASH = new TableBordersStyle("", "/", "/", "", "", "-", " ", "", "", "/", "/", "", "", " ", "", " ", " ");
    public static TableBordersStyle DESIGN_TUBES = new TableBordersStyle(" __ " + "|_||" + "|_||" + "|||" + "__");
    public static TableBordersStyle DESIGN_DOTS = new TableBordersStyle("\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7", "\u00b7");
    public static TableBordersStyle DESIGN_DIM = new TableBordersStyle("", "\u00a8", "\u00a8", "", "", "\u00a8", " ", "", "", "\u00a8", "\u00a8", "", "", " ", "", "\u00a8", "\u00a8");
    public static TableBordersStyle DESIGN_CURTAIN = new TableBordersStyle("o~", "~", "~", "~o", "  ", "-", " ", "  ", "o~", "~", "~", "~o", "  ", " ", "  ", " ", " ");
    public static TableBordersStyle DESIGN_CURTAIN_HEAVY = new TableBordersStyle("o=", "=", "=", "=o", "  ", "-", " ", "  ", "o=", "=", "=", "=o", "  ", " ", "  ", " ", " ");
    public static TableBordersStyle DESIGN_PAPYRUS = new TableBordersStyle("o~~~", "~", "~~", "~~~o", " )  ", "~", "  ", "  (", "o~~~", "~", "~~", "~~~o", " )  ", "  ", "  (", "  ", "  ");
    public static TableBordersStyle DESIGN_FORMAL_WIDE = new TableBordersStyle("", "=", "==", "", "", "-", "  ", "", "", "=", "==", "", "", "  ", "", "  ", "  ");
    public static TableBordersStyle DESIGN_FORMAL_INVERSE_WIDE = new TableBordersStyle("", "-", "--", "", "", "=", "  ", "", "", "-", "--", "", "", "  ", "", "  ", "  ");
    public static TableBordersStyle DESIGN_CASUAL_WIDE = new TableBordersStyle("", "=", "==", "", "", "~", "  ", "", "", "=", "==", "", "", "  ", "", "  ", "  ");
    public static TableBordersStyle DESIGN_CAFE_WIDE = new TableBordersStyle("", "~", "~~", "", "", "~", "  ", "", "", "~", "~~", "", "", "  ", "", "  ", "  ");
    public static TableBordersStyle DESIGN_SLASH_WIDE = new TableBordersStyle("", "/", "//", "", "", "-", "  ", "", "", "/", "//", "", "", "  ", "", "  ", "  ");
    public static TableBordersStyle DESIGN_TUBES_WIDE = new TableBordersStyle(" _", "_", "___", "_ ", "|_", "_", "_|_", "_|", "|_", "_", "_|_", "_|", "| ", " | ", " |", "___", "___");
    public static TableBordersStyle DESIGN_DOTS_WIDE = new TableBordersStyle("\u00b7\u00b7", "\u00b7", "\u00b7\u00b7\u00b7", "\u00b7\u00b7", "\u00b7\u00b7", "\u00b7", "\u00b7\u00b7\u00b7", " \u00b7", "\u00b7\u00b7", "\u00b7", "\u00b7\u00b7\u00b7", "\u00b7\u00b7", "\u00b7 ", " \u00b7 ", " \u00b7", "\u00b7\u00b7\u00b7", "\u00b7\u00b7\u00b7");
    public static TableBordersStyle DESIGN_DIM_WIDE = new TableBordersStyle("", "\u00a8", "\u00a8\u00a8", "", "", "\u00a8", "  ", "", "", "\u00a8", "\u00a8\u00a8", "", "", "  ", "", "  ", "  ");
    public static TableBordersStyle DESIGN_CURTAIN_WIDE = new TableBordersStyle("o~", "~", "~~", "~o", "  ", "-", "  ", "  ", "o~", "~", "~~", "~o", "  ", "  ", "  ", "  ", "  ");
    public static TableBordersStyle DESIGN_CURTAIN_HEAVY_WIDE = new TableBordersStyle("o=", "=", "==", "=o", "  ", "-", "  ", "  ", "o=", "=", "==", "=o", "  ", "  ", "  ", "  ", "  ");
    public static TableBordersStyle UNICODE_BOX = new TableBordersStyle("\u250c\u2500\u252c\u2510" + "\u251c\u2500\u253c\u2524" + "\u2514\u2500\u2534\u2518" + "\u2502\u2502\u2502" + "\u2534\u252c");
    public static TableBordersStyle UNICODE_ROUND_BOX = new TableBordersStyle("\u256d\u2500\u252c\u256e" + "\u251c\u2500\u253c\u2524" + "\u2570\u2500\u2534\u256f" + "\u2502\u2502\u2502" + "\u2534\u252c");
    public static TableBordersStyle UNICODE_HEAVY_BOX = new TableBordersStyle("\u250f\u2501\u2533\u2513" + "\u2523\u2501\u254b\u252b" + "\u2517\u2501\u253b\u251b" + "\u2503\u2503\u2503" + "\u253b\u2533");
    public static TableBordersStyle UNICODE_BOX_HEAVY_BORDER = new TableBordersStyle("\u250f\u2501\u252f\u2513" + "\u2520\u2500\u253c\u2528" + "\u2517\u2501\u2537\u251b" + "\u2503\u2502\u2503" + "\u2534\u252c");
    public static TableBordersStyle UNICODE_DOUBLE_BOX = new TableBordersStyle("\u2554\u2550\u2566\u2557" + "\u2560\u2550\u256c\u2563" + "\u255a\u2550\u2569\u255d" + "\u2551\u2551\u2551" + "\u2569\u2566");
    public static TableBordersStyle UNICODE_BOX_DOUBLE_BORDER = new TableBordersStyle("\u2554\u2550\u2564\u2557" + "\u255f\u2500\u253c\u2562" + "\u255a\u2550\u2567\u255d" + "\u2551\u2502\u2551" + "\u2534\u252c");
    public static TableBordersStyle UNICODE_BOX_WIDE = new TableBordersStyle("\u250c\u2500", "\u2500", "\u2500\u252c\u2500", "\u2500\u2510", "\u251c\u2500", "\u2500", "\u2500\u253c\u2500", "\u2500\u2524", "\u2514\u2500", "\u2500", "\u2500\u2534\u2500", "\u2500\u2518", "\u2502 ", " \u2502 ", " \u2502", "\u2500\u2534\u2500", "\u2500\u252c\u2500");
    public static TableBordersStyle UNICODE_ROUND_BOX_WIDE = new TableBordersStyle("\u256d\u2500", "\u2500", "\u2500\u252c\u2500", "\u2500\u256e", "\u251c\u2500", "\u2500", "\u2500\u253c\u2500", "\u2500\u2524", "\u2570\u2500", "\u2500", "\u2500\u2534\u2500", "\u2500\u256f", "\u2502 ", " \u2502 ", " \u2502", "\u2500\u2534\u2500", "\u2500\u252c\u2500");
    public static TableBordersStyle UNICODE_HEAVY_BOX_WIDE = new TableBordersStyle("\u250f\u2501", "\u2501", "\u2501\u2533\u2501", "\u2501\u2513", "\u2523\u2501", "\u2501", "\u2501\u254b\u2501", "\u2501\u252b", "\u2517\u2501", "\u2501", "\u2501\u253b\u2501", "\u2501\u251b", "\u2503 ", " \u2503 ", " \u2503", "\u2501\u253b\u2501", "\u2501\u2533\u2501");
    public static TableBordersStyle UNICODE_BOX_HEAVY_BORDER_WIDE = new TableBordersStyle("\u250f\u2501", "\u2501", "\u2501\u252f\u2501", "\u2501\u2513", "\u2520\u2500", "\u2500", "\u2500\u253c\u2500", "\u2500\u2528", "\u2517\u2501", "\u2501", "\u2501\u2537\u2501", "\u2501\u251b", "\u2503 ", " \u2502 ", " \u2503", "\u2500\u2534\u2500", "\u2500\u252c\u2500");
    public static TableBordersStyle UNICODE_DOUBLE_BOX_WIDE = new TableBordersStyle("\u2554\u2550", "\u2550", "\u2550\u2566\u2550", "\u2550\u2557", "\u2560\u2550", "\u2550", "\u2550\u256c\u2550", "\u2550\u2563", "\u255a\u2550", "\u2550", "\u2550\u2569\u2550", "\u2550\u255d", "\u2551 ", " \u2551 ", " \u2551", "\u2550\u2569\u2550", "\u2550\u2566\u2550");
    public static TableBordersStyle UNICODE_BOX_DOUBLE_BORDER_WIDE = new TableBordersStyle("\u2554\u2550", "\u2550", "\u2550\u2564\u2550", "\u2550\u2557", "\u255f\u2500", "\u2500", "\u2500\u253c\u2500", "\u2500\u2562", "\u255a\u2550", "\u2550", "\u2550\u2567\u2550", "\u2550\u255d", "\u2551 ", " \u2502 ", " \u2551", "\u2500\u2534\u2500", "\u2500\u252c\u2500");

    private const string DEFAULT_TILE = "*";

    /// <summary>
    /// Gets or sets the bottom-center corner
    /// </summary>
    public string BottomCenterCorner { get; set; }

    /// <summary>
    /// Gets or sets the bottom-left corner
    /// </summary>
    public string BottomLeftCorner { get; set; }

    /// <summary>
    /// Gets or sets the bottom
    /// </summary>
    public string Bottom { get; set; }

    /// <summary>
    /// Gets or sets the bottom-right corner
    /// </summary>
    public string BottomRightCorner { get; set; }

    /// <summary>
    /// Gets or sets the center
    /// </summary>
    public string Center { get; set; }

    /// <summary>
    /// Gets or sets the left
    /// </summary>
    public string Left { get; set; }

    /// <summary>
    /// Gets or sets the middle-center corner
    /// </summary>
    public string MiddleCenterCorner { get; set; }

    /// <summary>
    /// Gets or sets the middle
    /// </summary>
    public string Middle { get; set; }

    /// <summary>
    /// Gets or sets the middle-left corner
    /// </summary>
    public string MiddleLeftCorner { get; set; }

    /// <summary>
    /// Gets or sets the middle-right corner
    /// </summary>
    public string MiddleRightCorner { get; set; }

    /// <summary>
    /// Gets or sets the right
    /// </summary>
    public string Right { get; set; }

    /// <summary>
    /// Gets or sets the top
    /// </summary>
    public string Top { get; set; }

    /// <summary>
    /// Gets or sets the top-center corner
    /// </summary>
    public string TopCenterCorner { get; set; }

    /// <summary>
    /// Gets or sets the top-left corner
    /// </summary>
    public string TopLeftCorner { get; set; }

    /// <summary>
    /// Gets or sets the top-right corner
    /// </summary>
    public string TopRightCorner { get; set; }

    /// <summary>
    /// Gets or sets the upper column span
    /// </summary>
    public string UpperColumnSpan { get; set; }

    /// <summary>
    /// Gets or sets the lower column span
    /// </summary>
    public string LowerColumnSpan { get; set; }

    /// <summary>
    /// Gets or sets the left width
    /// </summary>
    public int LeftWidth { get; set; }

    /// <summary>
    /// Gets or sets the horizontal width
    /// </summary>
    public int HorizontalWidth { get; set; }

    /// <summary>
    /// Gets or sets the center width
    /// </summary>
    public int CenterWidth { get; set; }

    /// <summary>
    /// Gets or sets the right width
    /// </summary>
    public int RightWidth { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public TableBordersStyle() { }

    private TableBordersStyle(string tLCorner, string top,
                              string tCCorner, string tRCorner, string mLCorner,
                              string middle, string mCCorner, string mRCorner,
                              string bLCorner, string bottom, string bCCorner,
                              string bRCorner, string left, string center,
                              string right, string upperColSpan, string lowerColSpan)
    {

      LeftWidth = MaxWidth(tLCorner, mLCorner, bLCorner, left);
      HorizontalWidth = 1;
      CenterWidth = MaxWidth(tCCorner, mCCorner, bCCorner, center, upperColSpan, lowerColSpan);
      RightWidth = MaxWidth(tRCorner, mRCorner, bRCorner, right);

      TopLeftCorner = Adjuststring(tLCorner, LeftWidth);
      Top = Adjuststring(top, HorizontalWidth);
      TopCenterCorner = Adjuststring(tCCorner, CenterWidth);
      TopRightCorner = Adjuststring(tRCorner, RightWidth);
      MiddleLeftCorner = Adjuststring(mLCorner, LeftWidth);
      Middle = Adjuststring(middle, HorizontalWidth);
      MiddleCenterCorner = Adjuststring(mCCorner, CenterWidth);
      MiddleRightCorner = Adjuststring(mRCorner, RightWidth);
      BottomLeftCorner = Adjuststring(bLCorner, LeftWidth);
      Bottom = Adjuststring(bottom, HorizontalWidth);
      BottomCenterCorner = Adjuststring(bCCorner, CenterWidth);
      BottomRightCorner = Adjuststring(bRCorner, RightWidth);
      Left = Adjuststring(left, LeftWidth);
      Center = Adjuststring(center, CenterWidth);
      Right = Adjuststring(right, RightWidth);
      UpperColumnSpan = Adjuststring(upperColSpan, CenterWidth);
      LowerColumnSpan = Adjuststring(lowerColSpan, CenterWidth);
    }

    private TableBordersStyle(string customStyle)
    {
      LeftWidth = 1;
      HorizontalWidth = 1;
      CenterWidth = 1;
      RightWidth = 1;

      TopLeftCorner = Get(customStyle, 0);
      Top = Get(customStyle, 1);
      TopCenterCorner = Get(customStyle, 2);
      TopRightCorner = Get(customStyle, 3);
      MiddleLeftCorner = Get(customStyle, 4);
      Middle = Get(customStyle, 5);
      MiddleCenterCorner = Get(customStyle, 6);
      MiddleRightCorner = Get(customStyle, 7);
      BottomLeftCorner = Get(customStyle, 8);
      Bottom = Get(customStyle, 9);
      BottomCenterCorner = Get(customStyle, 10);
      BottomRightCorner = Get(customStyle, 11);
      Left = Get(customStyle, 12);
      Center = Get(customStyle, 13);
      Right = Get(customStyle, 14);
      UpperColumnSpan = Get(customStyle, 15);
      LowerColumnSpan = Get(customStyle, 16);
    }

    private static string Get(string style, int index)
    {
      if (style == null) return DEFAULT_TILE;      
      if (index < 0 || index >= style.Length) return DEFAULT_TILE;      
      return style.Substring(index, 1);
    }
    private static int MaxWidth(string a, string b, string c)
    {
      return Math.Max(Math.Max(TileWidth(a), TileWidth(b)), TileWidth(c));
    }
    private static int MaxWidth(string a, string b, string c, string d)
    {
      return Math.Max(Math.Max(Math.Max(TileWidth(a), TileWidth(b)), TileWidth(c)), TileWidth(d));
    }
    private static int MaxWidth(string a, string b, string c, string d, string e, string f)
    {
      return Math.Max(MaxWidth(a, b, c), MaxWidth(d, e, f));
    }
    private static string Adjuststring(string txt, int width)
    {
      if (txt == null) return Filler.GetFiller(width);      
      if (txt.Length == width) return txt;      
      if (txt.Length > width) return txt.Substring(0, width);      
      var diff = width - txt.Length;
      return txt + Filler.GetFiller(diff);
    }
    private static int TileWidth(string tile)
    {
      return tile?.Length ?? 0;
    }
  }
}
