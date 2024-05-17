using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class Font
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      if (Script != null)
      {
        sb.Append(Script);
      }
      if (Typeface!=null)
      {
        if (sb.Length > 0)
          sb.Append("=");
        sb.Append(Typeface);
      }
      return sb.ToString();
    }
  }
}
