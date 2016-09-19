using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextTableFormatter.UnitTests
{
  [TestClass]
  public class TableColSpanUnitTests
  {
    [TestMethod]
    [TestCategory("TableColSpanTests")]
    public void TestWideNullCell()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(5, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.AddCell(null, cellStyle, 5);

      Assert.AreEqual(""
                      + "+----+\n"
                      + "|    |\n"
                      + "+----+", table.Render());
    }

    [TestMethod]
    [TestCategory("TableColSpanTests")]
    public void TestWideIncompleteNullCell()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(7, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, string.Empty);
      table.AddCell(null, cellStyle, 3);

      Assert.AreEqual(""
                      + "+--+++++\n"
                      + "|  |||||\n"
                      + "+--+++++", table.Render());
    }

    [TestMethod]
    [TestCategory("TableColSpanTests")]
    public void TestSetColSpan()
    {
      var cs = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var csr = new CellStyle(CellHorizontalAlignment.Right, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var csc = new CellStyle(CellHorizontalAlignment.Center, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(2, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.Columns.ElementAt(0).SetWidthRange(6, 10);
      table.Columns.ElementAt(1).SetWidthRange(2, 7);

      table.AddCell("abcd", cs);
      table.AddCell("123456", cs);
      table.AddCell("mno", cs, 2);
      table.AddCell("xyztu", csr, 2);
      table.AddCell("efgh", csc, 2);

      Assert.AreEqual(""
                      + "+------+------+\n"
                      + "|abcd  |123456|\n"
                      + "+-------------+\n"
                      + "|mno          |\n"
                      + "+-------------+\n"
                      + "|        xyztu|\n"
                      + "+-------------+\n"
                      + "|    efgh     |\n"
                      + "+-------------+", table.Render());
    }

    [TestMethod]
    [TestCategory("TableColSpanTests")]
    public void TestCenteredColSpan()
    {
      var cellStyle1 = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var cellStyle2 = new CellStyle(CellHorizontalAlignment.Right, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);

      var table = new TextTable(4, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, string.Empty);
      table.Columns[0].SetWidthRange(3, 10);
      table.Columns[1].SetWidthRange(2, 7);
      table.Columns[2].SetWidthRange(3, 10);

      table.AddCell("abcd", cellStyle1);
      table.AddCell("123456", cellStyle1);
      table.AddCell("efgh", cellStyle1);
      table.AddCell("789012", cellStyle1);

      table.AddCell("ijkl", cellStyle1);
      table.AddCell("mno", cellStyle1, 2);
      table.AddCell("345678", cellStyle1);

      table.AddCell("mnop", cellStyle1);
      table.AddCell("901234", cellStyle1);
      table.AddCell("qrst", cellStyle1);
      table.AddCell("567890", cellStyle1);

      Assert.AreEqual(""
                      + "+----+------+----+------+\n"
                      + "|abcd|123456|efgh|789012|\n"
                      + "+----+-----------+------+\n"
                      + "|ijkl|mno        |345678|\n"
                      + "+----+-----------+------+\n"
                      + "|mnop|901234|qrst|567890|\n"
                      + "+----+------+----+------+", table.Render());
    }

    [TestMethod]
    [TestCategory("TableColSpanTests")]
    public void TestSetColSpanWide()
    {
      var cellStyle1 = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var cellStyle2 = new CellStyle(CellHorizontalAlignment.Right, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var textTable = new TextTable(2, TableBordersStyle.CLASSIC_WIDE, TableVisibleBorders.ALL, false, "");
      textTable.Columns[0].SetWidthRange(6, 10);
      textTable.Columns[1].SetWidthRange(2, 7);

      textTable.AddCell("abcd", cellStyle1);
      textTable.AddCell("123456", cellStyle1);
      textTable.AddCell("mno", cellStyle1, 2);
      textTable.AddCell("xyztu", cellStyle2, 2);

      Assert.AreEqual(""
                      + "+--------+--------+\n"
                      + "| abcd   | 123456 |\n"
                      + "+-----------------+\n"
                      + "| mno             |\n"
                      + "+-----------------+\n"
                      + "|           xyztu |\n"
                      + "+-----------------+", textTable.Render());
    }

    [TestMethod]
    [TestCategory("TableColSpanTests")]
    public void TestTooWideCell()
    {
      var cellStyle = new CellStyle(CellHorizontalAlignment.Left, CellTextTrimmingStyle.Crop, CellNullStyle.EmptyString);
      var table = new TextTable(3, TableBordersStyle.CLASSIC, TableVisibleBorders.ALL, false, "");
      table.AddCell("abc", cellStyle, 5);
      table.AddCell("defg", cellStyle, 5);
      Assert.AreEqual(""
                      + "+----+\n"
                      + "|abc |\n"
                      + "+----+\n"
                      + "|defg|\n"
                      + "+----+", table.Render());
    }
  }
}