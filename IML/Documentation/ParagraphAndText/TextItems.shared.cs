using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class TextItems
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public string GetString ()
    {
      StringBuilder sb = new StringBuilder();
      foreach (DocumentContent item in this)
        if (item is TextItem)
          sb.Append((item as TextItem).GetString());
      return sb.ToString();
    }

    /// <summary>
    /// Domyślny operator konwersji na łańcuch
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator string (TextItems value)
    {
      return value.GetString();
    }

    /// <summary>
    /// Domyślny operator konwersji z łańcucha
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator TextItems(string value)
    {
      TextItems items = new TextItems();
      items.Add(new Text(value));
      return items;
    }
  }
}
