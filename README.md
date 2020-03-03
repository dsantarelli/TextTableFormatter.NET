# TextTableFormatter.NET

<p><strong>Project Description</strong></p>
<p>TextTableFormatter is a .NET porting of <a title="Java Text Table Formatter" href="http://texttablefmt.sourceforge.net/" target="_blank"> Java TextTableFormatter</a>.&nbsp;<br /> This library&nbsp;renders&nbsp;tables made of characters. The user add cells and can add format characteristics like predefined/custom table styles, text alignment, abbreviation, column width, border types, colspan, etc. <br />Also available on <a href="https://www.nuget.org/packages/TextTableFormatter.NET/" target="_blank">NuGet</a>. TextTableFormatter currently supports dotnet standard 2.0</p>

<p><img src="https://dariosantarelli.files.wordpress.com/2013/03/209137.jpg" alt="Screenshot" /></p>
<p><br /> <strong>Some code examples</strong></p>
<pre><span style="color: green;">// 1. BASIC TABLE EXAMPLE
</span><span style="color: blue;">var </span><span style="color: black;">basicTable = </span><span style="color: blue;">new </span><span style="color: #2b91af;">TextTable</span><span style="color: black;">(3);
basicTable.AddCell(</span><span style="color: #a31515;">"Artist"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"Album"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"Year"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"Jamiroquai"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"Emergency on Planet Earth"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"1993"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"Jamiroquai"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"The Return of the Space Cowboy"</span><span style="color: black;">);
basicTable.AddCell(</span><span style="color: #a31515;">"1994"</span><span style="color: black;">);
</span><span style="color: #2b91af;">Console</span><span style="color: black;">.WriteLine(basicTable.Render());

</span><span style="color: green;">// +----------+-------------------------------+-----+
// |Artist    |Album                          |Year |
// +----------+-------------------------------+-----+
// |Jamiroquai|Emergency on Planet Earth      |1993 |
// |Jamiroquai|The Return of the Space Cowboy |1994 |
// +----------+-------------------------------+-----+


// 2. ADVANCED TABLE EXAMPLE
</span><span style="color: blue;">var </span><span style="color: black;">numberStyleAdvancedTable = </span><span style="color: blue;">new </span><span style="color: #2b91af;">CellStyle</span><span style="color: black;">(</span><span style="color: #2b91af;">CellHorizontalAlignment</span><span style="color: black;">.Right);
</span><span style="color: blue;">var </span><span style="color: black;">advancedTable = </span><span style="color: blue;">new </span><span style="color: #2b91af;">TextTable</span><span style="color: black;">(3, </span><span style="color: #2b91af;">TableBordersStyle</span><span style="color: black;">.DESIGN_FORMAL, </span><span style="color: #2b91af;">TableVisibleBorders</span><span style="color: black;">.SURROUND_HEADER_FOOTER_AND_COLUMNS);
advancedTable.SetColumnWidthRange(0, 6, 14);
advancedTable.SetColumnWidthRange(1, 4, 12);
advancedTable.SetColumnWidthRange(2, 4, 12);

advancedTable.AddCell(</span><span style="color: #a31515;">"Region"</span><span style="color: black;">);
advancedTable.AddCell(</span><span style="color: #a31515;">"Orders"</span><span style="color: black;">, numberStyleAdvancedTable);
advancedTable.AddCell(</span><span style="color: #a31515;">"Sales"</span><span style="color: black;">, numberStyleAdvancedTable);

advancedTable.AddCell(</span><span style="color: #a31515;">"North"</span><span style="color: black;">);
advancedTable.AddCell(</span><span style="color: #a31515;">"6,345"</span><span style="color: black;">, numberStyleAdvancedTable);
advancedTable.AddCell(</span><span style="color: #a31515;">"$87.230"</span><span style="color: black;">, numberStyleAdvancedTable);

advancedTable.AddCell(</span><span style="color: #a31515;">"Center"</span><span style="color: black;">);
advancedTable.AddCell(</span><span style="color: #a31515;">"837"</span><span style="color: black;">, numberStyleAdvancedTable);
advancedTable.AddCell(</span><span style="color: #a31515;">"$12.855"</span><span style="color: black;">, numberStyleAdvancedTable);

advancedTable.AddCell(</span><span style="color: #a31515;">"South"</span><span style="color: black;">);
advancedTable.AddCell(</span><span style="color: #a31515;">"5,344"</span><span style="color: black;">, numberStyleAdvancedTable);
advancedTable.AddCell(</span><span style="color: #a31515;">"$72.561"</span><span style="color: black;">, numberStyleAdvancedTable);

advancedTable.AddCell(</span><span style="color: #a31515;">"Total"</span><span style="color: black;">, numberStyleAdvancedTable, 2);
advancedTable.AddCell(</span><span style="color: #a31515;">"$172.646"</span><span style="color: black;">, numberStyleAdvancedTable);

</span><span style="color: #2b91af;">Console</span><span style="color: black;">.WriteLine(advancedTable.Render());

</span><span style="color: green;">// ======================
// Region Orders    Sales
// ------ ------ --------
// North   6,345  $87.230
// Center    837  $12.855
// South   5,344  $72.561
// ------ ------ --------
//         Total $172.646
// ======================


// 3. FANCY TABLE EXAMPLE
</span><span style="color: blue;">var </span><span style="color: black;">numberStyleFancyTable = </span><span style="color: blue;">new </span><span style="color: #2b91af;">CellStyle</span><span style="color: black;">(</span><span style="color: #2b91af;">CellHorizontalAlignment</span><span style="color: black;">.Right);
</span><span style="color: blue;">var </span><span style="color: black;">fancyTable = </span><span style="color: blue;">new </span><span style="color: #2b91af;">TextTable</span><span style="color: black;">(3, </span><span style="color: #2b91af;">TableBordersStyle</span><span style="color: black;">.DESIGN_PAPYRUS, </span><span style="color: #2b91af;">TableVisibleBorders</span><span style="color: black;">.SURROUND_HEADER_FOOTER_AND_COLUMNS);

fancyTable.AddCell(</span><span style="color: #a31515;">"Region"</span><span style="color: black;">);
fancyTable.AddCell(</span><span style="color: #a31515;">"Orders"</span><span style="color: black;">, numberStyleFancyTable);
fancyTable.AddCell(</span><span style="color: #a31515;">"Sales"</span><span style="color: black;">, numberStyleFancyTable);

fancyTable.AddCell(</span><span style="color: #a31515;">"North"</span><span style="color: black;">);
fancyTable.AddCell(</span><span style="color: #a31515;">"6,345"</span><span style="color: black;">, numberStyleFancyTable);
fancyTable.AddCell(</span><span style="color: #a31515;">"$87.230"</span><span style="color: black;">, numberStyleFancyTable);

fancyTable.AddCell(</span><span style="color: #a31515;">"Center"</span><span style="color: black;">);
fancyTable.AddCell(</span><span style="color: #a31515;">"837"</span><span style="color: black;">, numberStyleFancyTable);
fancyTable.AddCell(</span><span style="color: #a31515;">"$12.855"</span><span style="color: black;">, numberStyleFancyTable);

fancyTable.AddCell(</span><span style="color: #a31515;">"South"</span><span style="color: black;">);
fancyTable.AddCell(</span><span style="color: #a31515;">"5,344"</span><span style="color: black;">, numberStyleFancyTable);
fancyTable.AddCell(</span><span style="color: #a31515;">"$72.561"</span><span style="color: black;">, numberStyleFancyTable);

fancyTable.AddCell(</span><span style="color: #a31515;">"Total"</span><span style="color: black;">, numberStyleFancyTable, 2);
fancyTable.AddCell(</span><span style="color: #a31515;">"$172.646"</span><span style="color: black;">, numberStyleFancyTable);

</span><span style="color: #2b91af;">Console</span><span style="color: black;">.WriteLine(fancyTable.Render());

</span><span style="color: green;">// o~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~o
//  )  Region  Orders     Sales  (
//  )  ~~~~~~  ~~~~~~  ~~~~~~~~  (
//  )  North    6,345   $87.230  (
//  )  Center     837   $12.855  (
//  )  South    5,344   $72.561  (
//  )  ~~~~~~  ~~~~~~  ~~~~~~~~  (
//  )           Total  $172.646  (
// o~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~o


// 4. UNICODE TABLE EXAMPLE
</span><span style="color: blue;">var </span><span style="color: black;">numberStyleUnicodeTable = </span><span style="color: blue;">new </span><span style="color: #2b91af;">CellStyle</span><span style="color: black;">(</span><span style="color: #2b91af;">CellHorizontalAlignment</span><span style="color: black;">.Right);
</span><span style="color: blue;">var </span><span style="color: black;">unicodeTable = </span><span style="color: blue;">new </span><span style="color: #2b91af;">TextTable</span><span style="color: black;">(3, </span><span style="color: #2b91af;">TableBordersStyle</span><span style="color: black;">.UNICODE_BOX_DOUBLE_BORDER_WIDE, </span><span style="color: #2b91af;">TableVisibleBorders</span><span style="color: black;">.SURROUND_HEADER_FOOTER_AND_COLUMNS, </span><span style="color: blue;">true</span><span style="color: black;">);

unicodeTable.AddCell(</span><span style="color: #a31515;">"Region"</span><span style="color: black;">);
unicodeTable.AddCell(</span><span style="color: #a31515;">"Orders"</span><span style="color: black;">, numberStyleUnicodeTable);
unicodeTable.AddCell(</span><span style="color: #a31515;">"Sales"</span><span style="color: black;">, numberStyleUnicodeTable);

unicodeTable.AddCell(</span><span style="color: #a31515;">"North"</span><span style="color: black;">);
unicodeTable.AddCell(</span><span style="color: #a31515;">"6,345"</span><span style="color: black;">, numberStyleUnicodeTable);
unicodeTable.AddCell(</span><span style="color: #a31515;">"$87.230"</span><span style="color: black;">, numberStyleUnicodeTable);

unicodeTable.AddCell(</span><span style="color: #a31515;">"Center"</span><span style="color: black;">);
unicodeTable.AddCell(</span><span style="color: #a31515;">"837"</span><span style="color: black;">, numberStyleUnicodeTable);
unicodeTable.AddCell(</span><span style="color: #a31515;">"$12.855"</span><span style="color: black;">, numberStyleUnicodeTable);

unicodeTable.AddCell(</span><span style="color: #a31515;">"South"</span><span style="color: black;">);
unicodeTable.AddCell(</span><span style="color: #a31515;">"5,344"</span><span style="color: black;">, numberStyleUnicodeTable);
unicodeTable.AddCell(</span><span style="color: #a31515;">"$72.561"</span><span style="color: black;">, numberStyleUnicodeTable);

unicodeTable.AddCell(</span><span style="color: #a31515;">"Total"</span><span style="color: black;">, numberStyleUnicodeTable, 2);
unicodeTable.AddCell(</span><span style="color: #a31515;">"$172.646"</span><span style="color: black;">, numberStyleUnicodeTable);
           
</span><span style="color: blue;">var </span><span style="color: black;">unicodeTableStringArray = unicodeTable.RenderAsStringArray();
</span><span style="color: blue;">var </span><span style="color: black;">sb = </span><span style="color: blue;">new </span><span style="color: #2b91af;">StringBuilder</span><span style="color: black;">(</span><span style="color: #a31515;">"&lt;html&gt;&lt;body&gt;&lt;pre&gt;"</span><span style="color: black;">);
</span><span style="color: blue;">foreach </span><span style="color: black;">(</span><span style="color: blue;">string </span><span style="color: black;">line </span><span style="color: blue;">in </span><span style="color: black;">unicodeTableStringArray) 
{
    sb.Append(line);
    sb.Append(</span><span style="color: #a31515;">"&lt;br&gt;"</span><span style="color: black;">);
}
sb.Append(</span><span style="color: #a31515;">"&lt;/pre&gt;&lt;/html&gt;"</span><span style="color: black;">);

</span><span style="color: #2b91af;">File</span><span style="color: black;">.WriteAllText(</span><span style="color: #a31515;">"unicode.html"</span><span style="color: black;">, sb.ToString(), </span><span style="color: #2b91af;">Encoding</span><span style="color: black;">.UTF8);

</span><span style="color: green;">// unicode.html
// ╔════════╤════════╤══════════╗
// ║ Region │ Orders │    Sales ║
// ╟────────┼────────┼──────────╢
// ║ North  │  6,345 │  $87.230 ║
// ║ Center │    837 │  $12.855 ║
// ║ South  │  5,344 │  $72.561 ║
// ╟────────┴────────┼──────────╢
// ║           Total │ $172.646 ║
// ╚═════════════════╧══════════╝</span></pre>

# License

[Apache License Version 2.0](https://github.com/dsantarelli/TextTableFormatter.NET/blob/master/LICENSE.md)
