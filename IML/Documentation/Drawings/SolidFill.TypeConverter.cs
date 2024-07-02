using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation.Drawings
{
  public partial class SolidFill
  {
    /// <summary>
    /// Czy może być serializowane do łańcucha
    /// </summary>
    /// <returns></returns>
    public override bool CanSerializeToString ()
    {
      return true;
    }

    /// <summary>
    /// Podaje kolor w postaci nazwy lub liczby szesnastkowej
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      if (Color == null)
        return "";
      return Color.ToString();
    }

    /// <summary>
    /// Konwersja z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static SolidFill Parse (string s)
    {
      SolidFill result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid SolidFill string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out SolidFill result)
    {
      Color val = new ColorTypeConverter().ConvertFromString(s) as Color;
      if (val!=null)
      {
        result = new SolidFill { Color = val };
        return true;
      }

      result = null;
      return false;
    }

  }
}
