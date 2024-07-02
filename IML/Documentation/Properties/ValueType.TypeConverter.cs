using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Iml.Documentation
{

  [TypeConverter(typeof(ValueTypeTypeConverter))]
  public partial class ValueType
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static ValueType Parse (string str)
    {
      ValueType result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse Value from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out ValueType value)
    {
      value = null;
      int k = str.IndexOf(' ');
      if (k < 0)
      {
        ValueTypes type;
        if (Enum.TryParse<ValueTypes>(str, out type))
        {
          value = type;
          return true;
        }
      }
      else
      {
        string s = FormatHelper.GetFirstWord(ref str);
        if (s == "Vector")
        {
          value = ValueTypes.Vector;
          s = FormatHelper.GetFirstWord(ref str);
          if (s==null)
            return true;
          if (s.StartsWith("["))
          {
            if (!s.EndsWith("]"))
              return false;
            s = s.Substring(1, s.Length - 2);
            int size;
            if (!int.TryParse(s, out size))
              return false;
            value.Size = size;
            s = FormatHelper.GetFirstWord(ref str);
          }
        }
        if (s=="of")
        {
          ValueType subtype;
          if (!ValueType.TryParse(str, out subtype))
            return false;
          value.BaseType = subtype;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb;
      switch (Type)
      {
        case ValueTypes.Vector:
          sb = new StringBuilder();
          sb.Append("Vector");
          if (Size != null)
            sb.Append(" [" + Size.ToString() + "]");
          if (BaseType!=null)
            sb.Append(" of " + BaseType.ToString());
          return sb.ToString();
      }
      return Type.ToString();
    }


  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class ValueTypeTypeConverter : TypeConverter
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
      if (!(destinationType == typeof(string)))
      {
        return base.CanConvertTo(context, destinationType);
      }
      if ((context != null))
      {
        if (context.PropertyDescriptor != null)
        {
          return true;
        }
        return false;
      }
      return base.CanConvertTo(context, destinationType);
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        ValueType result = ValueType.Parse(value as string);
        return result;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is ValueType)
      {
        ValueType val = (ValueType)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}

