using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{

  [TypeConverter(typeof(FormulasTypeConverter))]
  public partial class Formulas
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Formulas Parse (string str)
    {
      Formulas result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse Formulas from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out Formulas value)
    {
      value = new Formulas();
      string[] ss = str.Split(',');
      foreach (string s in ss)
        value.Add(new Formula{ Equation = s.Trim()});
      return true;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      int n = 0;
      foreach (Formula item in this)
      {
        if (n++!=0)
          sb.Append(", ");
        sb.Append((item as Formula).ToString());
      }
      return sb.ToString();
    }


  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class FormulasTypeConverter : TypeConverter
  {
    /// <summary>
    /// Konwersja z postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
    {
      if (!(sourceType == typeof(string)))
      {
        return base.CanConvertTo(context, sourceType);
      }
      if ((context == null) || (context.Instance == null))
      {
        return true;
      }
      if (context.PropertyDescriptor != null
        && context.PropertyDescriptor.PropertyType == typeof(Formulas))
      {
        return true;
      }
      return false;//throw new ArgumentException("Formulas instance expected");
    }

    /// <summary>
    /// Konwersja do postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
    {
      if (!(destinationType == typeof(string)))
      {
        return base.CanConvertTo(context, destinationType);
      }
      if ((context == null) || (context.Instance == null))
      {
        return true;
      }
      if (context.PropertyDescriptor != null
        && context.PropertyDescriptor.PropertyType == typeof(Formulas))
      {
        return true;
      }
      return false;//throw new ArgumentException("Formulas instance expected");
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        Formulas val;
        if (Formulas.TryParse(value as String, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if ((destinationType != null) && (value is Formulas))
      {
        Formulas val = (Formulas)value;
        if (destinationType == typeof(string))
        {
          return val.ToString();
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);

    }
  }
}


