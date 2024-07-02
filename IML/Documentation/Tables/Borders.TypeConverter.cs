using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(BordersTypeConverter))]
  public partial class Borders
  {
    /// <summary>
    /// Konwersja na łańcuch.
    /// </summary>
    public override string ToString ()
    {
      //BorderLinePlacement commonPlacement = 0;
      //BorderLine aLine = null;
      //BorderLine frameLine = null;
      //BorderLine insideLine = null;
      //BorderLine gridLine = null;
      //OrderedDictionary lines = new OrderedDictionary();
      //foreach (BorderLine borderLine in this)
      //  lines.Add(borderLine.Placement, borderLine);

      //foreach (BorderLine borderLine in lines)
      //{
      //  if (borderLine.Placement <= BorderLinePlacement.Grid)
      //  {
      //    if (aLine == null || !borderLine.Equals(aLine))
      //    {
      //      aLine = borderLine;
      //      commonPlacement = borderLine.Placement;
      //    }
      //    else
      //    {
      //      commonPlacement |= borderLine.Placement;
      //      if (commonPlacement == BorderLinePlacement.Frame)
      //      {
      //        frameLine = aLine;
      //      }
      //      else if (commonPlacement == BorderLinePlacement.InsideLines)
      //      {
      //        insideLine = aLine;
      //      }
      //      else if (commonPlacement == BorderLinePlacement.Grid)
      //      {
      //        frameLine = null;
      //        gridLine = aLine;
      //      }
      //    }
      //  }
      //}
      //if (frameLine != null)
      //{
      //  lines.Remove(BorderLinePlacement.Left);
      //  lines.Remove(BorderLinePlacement.Top);
      //  lines.Remove(BorderLinePlacement.Right);
      //  lines.Remove(BorderLinePlacement.Bottom);
      //  lines.Add(BorderLinePlacement.Frame, frameLine);
      //}
      StringBuilder sb = new StringBuilder();
      int n = 0;
      foreach (BorderLine borderLine in this)
      {
        if (n++ != 0)
          sb.Append(", ");
        sb.Append(borderLine.Placement.ToString());
        sb.Append("(");
        sb.Append(borderLine.ToStringNoPlacement());
        sb.Append(")");
      }
      string result = sb.ToString();
      return result;
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static Borders Parse (string s)
    {
      Borders result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Borders string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out Borders result)
    {
      result = new Borders();
      string[] ss = FormatHelper.TrySplitList(str);
      foreach (string s in ss)
      {
        int k = s.IndexOf('(');
        if (k<=0 || k>=s.Length-1)
         return false;
        string placementStr = s.Substring(0, k);
        string rest = s.Substring(k).TryTrimListSeparators();
        string borderLineStr = "Placement=" + placementStr;
        if (!String.IsNullOrEmpty(rest))
          borderLineStr += ", " + rest;
        BorderLine line;
        if (!BorderLine.TryParse(borderLineStr, out line))
          return false;
        result.Add(line);
      }
      return true;
    }

  }

  /// <summary>
  /// Konwerter marginesów komórki. 
  /// </summary>
  public partial class BordersTypeConverter : TypeConverter
  {
    /// <summary>
    /// Konwersja z postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(string))
        return true;
      else
        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof(string))
        return true;
      else
        return base.CanConvertTo(context, destinationType);
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string s = (string)value;
        Borders val;
        if (Borders.TryParse(s, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is Borders)
      {
        return (value as Borders).ToString();
      }
      else
        return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

