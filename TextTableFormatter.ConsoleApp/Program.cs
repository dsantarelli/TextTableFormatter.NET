using System;
using System.IO;
using System.Text;

namespace TextTableFormatter.ConsoleApp
{
  class Program
  {
    static void Main()
    {
      // 1. BASIC TABLE EXAMPLE
      var basicTable = new TextTable(3);
      basicTable.AddCell("Artist");
      basicTable.AddCell("Album");
      basicTable.AddCell("Year");
      basicTable.AddCell("Jamiroquai");
      basicTable.AddCell("Emergency on Planet Earth");
      basicTable.AddCell("1993");
      basicTable.AddCell("Jamiroquai");
      basicTable.AddCell("The Return of the Space Cowboy");
      basicTable.AddCell("1994");
      Console.WriteLine(basicTable.Render());

      // +----------+-------------------------------+-----+
      // |Artist    |Album                         |Year|
      // +----------+-------------------------------+-----+
      // |Jamiroquai|Emergency on Planet Earth     |1993|
      // |Jamiroquai|The Return of the Space Cowboy|1994|
      // +----------+-------------------------------+-----+


      // 2. ADVANCED TABLE EXAMPLE
      var numberStyleAdvancedTable = new CellStyle(CellHorizontalAlignment.Right);
      var advancedTable = new TextTable(3, TableBordersStyle.DESIGN_FORMAL, TableVisibleBorders.SURROUND_HEADER_FOOTER_AND_COLUMNS);
      advancedTable.SetColumnWidthRange(0, 6, 14);
      advancedTable.SetColumnWidthRange(1, 4, 12);
      advancedTable.SetColumnWidthRange(2, 4, 12);

      advancedTable.AddCell("Region");
      advancedTable.AddCell("Orders", numberStyleAdvancedTable);
      advancedTable.AddCell("Sales", numberStyleAdvancedTable);

      advancedTable.AddCell("North");
      advancedTable.AddCell("6,345", numberStyleAdvancedTable);
      advancedTable.AddCell("$87.230", numberStyleAdvancedTable);

      advancedTable.AddCell("Center");
      advancedTable.AddCell("837", numberStyleAdvancedTable);
      advancedTable.AddCell("$12.855", numberStyleAdvancedTable);

      advancedTable.AddCell("South");
      advancedTable.AddCell("5,344", numberStyleAdvancedTable);
      advancedTable.AddCell("$72.561", numberStyleAdvancedTable);

      advancedTable.AddCell("Total", numberStyleAdvancedTable, 2);
      advancedTable.AddCell("$172.646", numberStyleAdvancedTable);

      Console.WriteLine(advancedTable.Render());

      // ======================
      // Region Orders    Sales
      // ------ ------ --------
      // North   6,345  $87.230
      // Center    837  $12.855
      // South   5,344  $72.561
      // ------ ------ --------
      //         Total $172.646
      // ======================


      // 3. FANCY TABLE EXAMPLE
      var numberStyleFancyTable = new CellStyle(CellHorizontalAlignment.Right);
      var fancyTable = new TextTable(3, TableBordersStyle.DESIGN_PAPYRUS, TableVisibleBorders.SURROUND_HEADER_FOOTER_AND_COLUMNS);

      fancyTable.AddCell("Region");
      fancyTable.AddCell("Orders", numberStyleFancyTable);
      fancyTable.AddCell("Sales", numberStyleFancyTable);

      fancyTable.AddCell("North");
      fancyTable.AddCell("6,345", numberStyleFancyTable);
      fancyTable.AddCell("$87.230", numberStyleFancyTable);

      fancyTable.AddCell("Center");
      fancyTable.AddCell("837", numberStyleFancyTable);
      fancyTable.AddCell("$12.855", numberStyleFancyTable);

      fancyTable.AddCell("South");
      fancyTable.AddCell("5,344", numberStyleFancyTable);
      fancyTable.AddCell("$72.561", numberStyleFancyTable);

      fancyTable.AddCell("Total", numberStyleFancyTable, 2);
      fancyTable.AddCell("$172.646", numberStyleFancyTable);

      Console.WriteLine(fancyTable.Render());

      // o~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~o
      //  )  Region  Orders     Sales  (
      //  )  ~~~~~~  ~~~~~~  ~~~~~~~~  (
      //  )  North    6,345   $87.230  (
      //  )  Center     837   $12.855  (
      //  )  South    5,344   $72.561  (
      //  )  ~~~~~~  ~~~~~~  ~~~~~~~~  (
      //  )           Total  $172.646  (
      // o~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~o


      // 4. UNICODE TABLE EXAMPLE
      var numberStyleUnicodeTable = new CellStyle(CellHorizontalAlignment.Right);
      var unicodeTable = new TextTable(3, TableBordersStyle.UNICODE_BOX_DOUBLE_BORDER_WIDE, TableVisibleBorders.SURROUND_HEADER_FOOTER_AND_COLUMNS, true);

      unicodeTable.AddCell("Region");
      unicodeTable.AddCell("Orders", numberStyleUnicodeTable);
      unicodeTable.AddCell("Sales", numberStyleUnicodeTable);

      unicodeTable.AddCell("North");
      unicodeTable.AddCell("6,345", numberStyleUnicodeTable);
      unicodeTable.AddCell("$87.230", numberStyleUnicodeTable);

      unicodeTable.AddCell("Center");
      unicodeTable.AddCell("837", numberStyleUnicodeTable);
      unicodeTable.AddCell("$12.855", numberStyleUnicodeTable);

      unicodeTable.AddCell("South");
      unicodeTable.AddCell("5,344", numberStyleUnicodeTable);
      unicodeTable.AddCell("$72.561", numberStyleUnicodeTable);

      unicodeTable.AddCell("Total", numberStyleUnicodeTable, 2);
      unicodeTable.AddCell("$172.646", numberStyleUnicodeTable);

      var unicodeTableStringArray = unicodeTable.RenderAsStringArray();
      var sb = new StringBuilder("<html><body><pre>");
      foreach (string line in unicodeTableStringArray)
      {
        sb.Append(line);
        sb.Append("<br>");
      }
      sb.Append("</pre></html>");

      File.WriteAllText("unicode.html", sb.ToString(), Encoding.UTF8);

      // unicode.html
      // ╔════════╤════════╤══════════╗
      // ║ Region │ Orders │    Sales ║
      // ╟────────┼────────┼──────────╢
      // ║ North  │  6,345 │  $87.230 ║
      // ║ Center │    837 │  $12.855 ║
      // ║ South  │  5,344 │  $72.561 ║
      // ╟────────┴────────┼──────────╢
      // ║           Total │ $172.646 ║
      // ╚═════════════════╧══════════╝
    }
  }
}
