using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  public partial class FieldInstruction
  {

    /// <summary>
    /// Funkcja podaje łańcuch dla instrukcji
    /// </summary>
    /// <returns></returns>
    public string GetString ()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(Command);
      if (ShouldSerializeOptions())
      {
        foreach (NameValuePair option in Options)
        {
          sb.Append(" ");
          sb.Append(option.Name);
          if (option.Value!=null)
          {
            sb.Append(" ");
            sb.Append(option.Value.ToString());
          }
        }
      }
      if (ShouldSerializeParameters())
      {
        foreach (NameValuePair option in Parameters)
        {
          if (option.Value != null)
          {
            sb.Append(" ");
            sb.Append(option.Value.ToString());
          }
        }
      }
      return sb.ToString();
    }

  }
}
