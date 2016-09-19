using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextTableFormatter.UnitTests
{
  [TestClass]
  public class CellUnitTests
  {
    [TestMethod]
    [TestCategory("CellTests")]
    public void TestAlignLeft()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var cell = new Cell("abcdef", cellStyle, 1);
      Assert.AreEqual("", cell.Render(0));
      Assert.AreEqual("a", cell.Render(1));
      Assert.AreEqual("ab", cell.Render(2));
      Assert.AreEqual("abc", cell.Render(3));
      Assert.AreEqual("abcd", cell.Render(4));
      Assert.AreEqual("abcde", cell.Render(5));
      Assert.AreEqual("abcdef", cell.Render(6));
      Assert.AreEqual("abcdef ", cell.Render(7));
      Assert.AreEqual("abcdef  ", cell.Render(8));
      Assert.AreEqual("abcdef   ", cell.Render(9));
      Assert.AreEqual("abcdef    ", cell.Render(10));
      Assert.AreEqual("abcdef     ", cell.Render(11));
    }

    [TestMethod]
    [TestCategory("CellTests")]
    public void TestAlignCenter()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Center, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var cell = new Cell("abcdef", cellStyle, 1);
      Assert.AreEqual("", cell.Render(0));
      Assert.AreEqual("a", cell.Render(1));
      Assert.AreEqual("ab", cell.Render(2));
      Assert.AreEqual("abc", cell.Render(3));
      Assert.AreEqual("abcd", cell.Render(4));
      Assert.AreEqual("abcde", cell.Render(5));
      Assert.AreEqual("abcdef", cell.Render(6));
      Assert.AreEqual("abcdef ", cell.Render(7));
      Assert.AreEqual(" abcdef ", cell.Render(8));
      Assert.AreEqual(" abcdef  ", cell.Render(9));
      Assert.AreEqual("  abcdef  ", cell.Render(10));
      Assert.AreEqual("  abcdef   ", cell.Render(11));
    }

    [TestMethod]
    [TestCategory("CellTests")]
    public void TestAlignRight()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Right, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var cell = new Cell("abcdef", cellStyle, 1);
      Assert.AreEqual("", cell.Render(0));
      Assert.AreEqual("a", cell.Render(1));
      Assert.AreEqual("ab", cell.Render(2));
      Assert.AreEqual("abc", cell.Render(3));
      Assert.AreEqual("abcd", cell.Render(4));
      Assert.AreEqual("abcde", cell.Render(5));
      Assert.AreEqual("abcdef", cell.Render(6));
      Assert.AreEqual(" abcdef", cell.Render(7));
      Assert.AreEqual("  abcdef", cell.Render(8));
      Assert.AreEqual("   abcdef", cell.Render(9));
      Assert.AreEqual("    abcdef", cell.Render(10));
      Assert.AreEqual("     abcdef", cell.Render(11));
    }

    [TestMethod]
    [TestCategory("CellTests")]
    public void TestAbbreviateCrop()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var cell = new Cell("abcdef", cellStyle, 1);
      Assert.AreEqual("", cell.Render(0));
      Assert.AreEqual("a", cell.Render(1));
      Assert.AreEqual("ab", cell.Render(2));
      Assert.AreEqual("abc", cell.Render(3));
      Assert.AreEqual("abcd", cell.Render(4));
      Assert.AreEqual("abcde", cell.Render(5));
      Assert.AreEqual("abcdef", cell.Render(6));
      Assert.AreEqual("abcdef ", cell.Render(7));
    }

    [TestMethod]
    [TestCategory("CellTests")]
    public void TestAbbreviateDots()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Dots, CellNullStyle.EmptyString);
      var cell = new Cell("abcdef", cellStyle, 1);
      Assert.AreEqual("", cell.Render(0));
      Assert.AreEqual(".", cell.Render(1));
      Assert.AreEqual("..", cell.Render(2));
      Assert.AreEqual("...", cell.Render(3));
      Assert.AreEqual("a...", cell.Render(4));
      Assert.AreEqual("ab...", cell.Render(5));
      Assert.AreEqual("abcdef", cell.Render(6));
      Assert.AreEqual("abcdef ", cell.Render(7));
    }

    [TestMethod]
    [TestCategory("CellTests")]
    public void TestNullEmpty()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var cell = new Cell(null, cellStyle, 1);
      Assert.AreEqual("", cell.Render(0));
      Assert.AreEqual(" ", cell.Render(1));
      Assert.AreEqual("  ", cell.Render(2));
      Assert.AreEqual("   ", cell.Render(3));
      Assert.AreEqual("    ", cell.Render(4));
      Assert.AreEqual("          ", cell.Render(10));
      Assert.AreEqual("           ", cell.Render(11));
    }

    [TestMethod]
    [TestCategory("CellTests")]
    public void TestNullText()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.NullText);
      var cell = new Cell(null, cellStyle, 1);
      Assert.AreEqual("", cell.Render(0));
      Assert.AreEqual("<", cell.Render(1));
      Assert.AreEqual("<n", cell.Render(2));
      Assert.AreEqual("<nu", cell.Render(3));
      Assert.AreEqual("<nul", cell.Render(4));
      Assert.AreEqual("<null", cell.Render(5));
      Assert.AreEqual("<null>", cell.Render(6));
      Assert.AreEqual("<null> ", cell.Render(7));
      Assert.AreEqual("<null>     ", cell.Render(11));
    }

    private static readonly string FRS = ((char)27) + "[0m"; // Format reset sequence

    [TestMethod]
    [TestCategory("CellTests")]
    public void TestTerminalFormats()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop);
      const char esc = (char)27;

      var cell = new Cell("abc" + esc + "[23;45mdef", cellStyle, 1);
      Assert.AreEqual("a", cell.Render(1));
      Assert.AreEqual("ab", cell.Render(2));
      Assert.AreEqual("abc" + esc + "[23;45m" + FRS, cell.Render(3));
      Assert.AreEqual("abc" + esc + "[23;45md" + FRS, cell.Render(4));
      Assert.AreEqual("abc" + esc + "[23;45mdef" + FRS, cell.Render(6));
      Assert.AreEqual("abc" + esc + "[23;45mdef " + FRS, cell.Render(7));

      cell = new Cell(esc + "[23;45mdef", cellStyle, 1);
      Assert.AreEqual(esc + "[23;45md" + FRS, cell.Render(1));
      Assert.AreEqual(esc + "[23;45mde" + FRS, cell.Render(2));
      Assert.AreEqual(esc + "[23;45mdef" + FRS, cell.Render(3));
      Assert.AreEqual(esc + "[23;45mdef " + FRS, cell.Render(4));

      cell = new Cell("abc" + esc + "[23;45m", cellStyle, 1);
      Assert.AreEqual("a", cell.Render(1));
      Assert.AreEqual("ab", cell.Render(2));
      Assert.AreEqual("abc" + esc + "[23;45m" + FRS, cell.Render(3));
      Assert.AreEqual("abc" + esc + "[23;45m " + FRS, cell.Render(4));

      cell = new Cell("abc" + esc + "[23;45mdef" + esc + "[0mghi", cellStyle, 1);
      Assert.AreEqual("a", cell.Render(1));
      Assert.AreEqual("ab", cell.Render(2));
      Assert.AreEqual("abc" + esc + "[23;45m" + FRS, cell.Render(3));
      Assert.AreEqual("abc" + esc + "[23;45md" + FRS, cell.Render(4));
      Assert.AreEqual("abc" + esc + "[23;45mde" + FRS, cell.Render(5));
      Assert.AreEqual("abc" + esc + "[23;45mdef" + esc + "[0m" + FRS, cell.Render(6));
      Assert.AreEqual("abc" + esc + "[23;45mdef" + esc + "[0mg" + FRS, cell.Render(7));
      Assert.AreEqual("abc" + esc + "[23;45mdef" + esc + "[0mgh" + FRS, cell.Render(8));
      Assert.AreEqual("abc" + esc + "[23;45mdef" + esc + "[0mghi" + FRS, cell.Render(9));
      Assert.AreEqual("abc" + esc + "[23;45mdef" + esc + "[0mghi " + FRS, cell.Render(10));
    }
  }
}