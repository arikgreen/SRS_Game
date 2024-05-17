using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{

  [TypeConverter(typeof(TextItemsTypeConverter))]
  public partial class TextItems
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static TextItems Parse (string str)
    {
      TextItems result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse TextItems from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out TextItems value)
    {
      value = new TextItems();
      value.Add(new Text(str));
      return true;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      foreach (TextItem item in this)
      {
        sb.Append((item as TextItem).GetString());
      }
      return sb.ToString();
    }

    /// <summary>
    /// Czy może być serializowany do łańcucha
    /// </summary>
    /// <returns></returns>
    public bool CanSerializeToString()
    {
      return Count == 1 && this[0].GetType() == typeof(Text);
    }
  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class TextItemsTypeConverter : TypeConverter
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
      if (!(context.Instance is TextRun))
      {
        return false;//throw new ArgumentException("TextItems instance expected");
      }
      //TextRun instance = (TextRun)context.Instance;
      return true;// instance.Content.CanSerializeToString();
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
      if (!(context.Instance is TextRun))
      {
        return false;//throw new ArgumentException("TextItems instance expected");
      }
      TextRun instance = (TextRun)context.Instance;
      return instance.Content.CanSerializeToString();
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        TextItems val;
        if (TextItems.TryParse(value as String, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if ((destinationType != null) && (value is TextItems))
      {
        TextItems val = (TextItems)value;
        if (destinationType == typeof(string))
        {
          if (((context != null) && (context.Instance != null)) && !val.CanSerializeToString())
          {
            throw new NotSupportedException("Conversion not supported");
          }
          return val.ToString();
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);

    }
  }
}

