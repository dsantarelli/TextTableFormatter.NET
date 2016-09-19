using System.Text;

namespace TextTableFormatter
{
  internal static class TextEncoder
  {
    internal static string EscapeXml(string txt)
    {
      if (txt == null) return null;      
      var sb = new StringBuilder();
      for (int i = 0; i < txt.Length; i++)
      {
        var c = txt[i];
        if (c < 32 || c > 127 || c == '<' || c == '>' || c == '&' || c == '\''
            || c == '\"')
        {
          sb.Append("&#" + (int)c + ";");
        }
        else sb.Append(c);        
      }
      return sb.ToString();
    }
  }
}
