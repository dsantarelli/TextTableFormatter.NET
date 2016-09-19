using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextTableFormatter.UnitTests
{
  [TestClass]
  public class TableUnitTests
  {
    [TestMethod]
    [TestCategory("TableTests")]
    public void TestEmpty()
    {
      var table = new TextTable(10, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, string.Empty);
      Assert.AreEqual("", table.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestOneCell()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(1, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.AddCell("abcdef", cellStyle);

      Assert.AreEqual(""
          + "+------+\n"
          + "|abcdef|\n"
          + "+------+", table.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestNullCell()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(1, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.AddCell(null, cellStyle);
      Assert.AreEqual(""
          + "++\n"
          + "||\n"
          + "++", table.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestEmptyCell()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(1, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.AddCell("", cellStyle);
      Assert.AreEqual(""
          + "++\n"
          + "||\n"
          + "++", table.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestTwoCellsHorizontal()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var textTable = new TextTable(2, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      textTable.AddCell("abcdef", cellStyle);
      textTable.AddCell("123456", cellStyle);

      Assert.AreEqual(""
          + "+------+------+\n"
          + "|abcdef|123456|\n"
          + "+------+------+", textTable.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestTwoCellsVertical()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(1, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.AddCell("abcdef", cellStyle);
      table.AddCell("123456", cellStyle);

      Assert.AreEqual(""
          + "+------+\n"
          + "|abcdef|\n"
          + "+------+\n"
          + "|123456|\n"
          + "+------+", table.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestMarginPrompt()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var textTable = new TextTable(1, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "prompt");
      textTable.AddCell("abcdef", cellStyle);
      textTable.AddCell("123456", cellStyle);

      Assert.AreEqual(""
          + "prompt+------+\n"
          + "prompt|abcdef|\n"
          + "prompt+------+\n"
          + "prompt|123456|\n"
          + "prompt+------+", textTable.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestMarginSpaces()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var textTable = new TextTable(1, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, 4);
      textTable.AddCell("abcdef", cellStyle);
      textTable.AddCell("123456", cellStyle);

      Assert.AreEqual(""
          + "    +------+\n"
          + "    |abcdef|\n"
          + "    +------+\n"
          + "    |123456|\n"
          + "    +------+", textTable.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestAutomaticWidth()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var textTable = new TextTable(2, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      textTable.AddCell("abcdef", cellStyle);
      textTable.AddCell("123456", cellStyle);
      textTable.AddCell("mno", cellStyle);
      textTable.AddCell("45689", cellStyle);
      textTable.AddCell("xyztuvw", cellStyle);
      textTable.AddCell("01234567", cellStyle);

      Assert.AreEqual(""
          + "+-------+--------+\n"
          + "|abcdef |123456  |\n"
          + "+-------+--------+\n"
          + "|mno    |45689   |\n"
          + "+-------+--------+\n"
          + "|xyztuvw|01234567|\n"
          + "+-------+--------+", textTable.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestSetWidth()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(2, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.Columns[0].SetWidthRange(6, 10);
      table.Columns[1].SetWidthRange(2, 7);

      table.AddCell("abcd", cellStyle);
      table.AddCell("123456", cellStyle);
      table.AddCell("mno", cellStyle);
      table.AddCell("45689", cellStyle);
      table.AddCell("xyztu", cellStyle);
      table.AddCell("01234567", cellStyle);

      Assert.AreEqual(""
          + "+------+-------+\n"
          + "|abcd  |123456 |\n"
          + "+------+-------+\n"
          + "|mno   |45689  |\n"
          + "+------+-------+\n"
          + "|xyztu |0123456|\n"
          + "+------+-------+", table.Render());
    }

    [TestMethod]
    [TestCategory("TableTests")]
    public void TestMissingCell()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(2, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.Columns[0].SetWidthRange(6, 10);
      table.Columns[1].SetWidthRange(2, 7);

      table.AddCell("abcd", cellStyle);
      table.AddCell("123456", cellStyle);
      table.AddCell("mno", cellStyle);
      table.AddCell("45689", cellStyle);
      table.AddCell("xyztu", cellStyle);

      Assert.AreEqual(""
          + "+------+------+\n"
          + "|abcd  |123456|\n"
          + "+------+------+\n"
          + "|mno   |45689 |\n"
          + "+------+------+\n"
          + "|xyztu |      |\n"
          + "+------+------+", table.Render());
    }

  }
}
