using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Iml.Documentation
{

  //[TypeConverter(typeof(VectorValueConverter))]
  public partial class VectorValue
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="type">oczekiwany typ elementu </param>
    /// <returns></returns>
    public new static VectorValue Parse (string str, ValueType type)
    {
      VectorValue result;
      if (TryParse(str, type, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse VectorValue from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="VectorValue"></param>
    /// <param name="itemType">oczekiwany typ elementu</param>
    /// <returns></returns>
    public static bool TryParse (string str, ValueType itemType, out VectorValue VectorValue)
    {
      VectorValue = new VectorValue { Type = ValueTypes.Vector };
      str = str.TryTrimListSeparators();
      string[] ss = str.TrySplitList();
      foreach (string s in ss)
      {
        Value item;
        if (!Value.TryParse(s, itemType.BaseType, out item))
          return false;
        VectorValue.Content.Add(item);
      }
      return true;
    }


    /// <summary>
    /// Konwersja wektora na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(FormatHelper.ListStartSeparator);
      int n = 0;
      foreach (Value item in Content)
      {
        if (n++ != 0)
          sb.Append(FormatHelper.ListSeparator);
        sb.Append(item.ToString());
      }
      sb.Append(FormatHelper.ListEndSeparator);
      return sb.ToString();
    }


    ///// <summary>
    ///// Konwersja typu wartości na łańcuch
    ///// </summary>
    ///// <param name="type"></param>
    ///// <returns></returns>
    //public override string TypeToString ()
    //{
    //  StringBuilder sb = new StringBuilder();
    //  sb.Append("Vector");
    //  if (BaseType != null)
    //  {
    //    if (BaseType.Size != null)
    //      sb.Append(" [" + BaseType.Size.ToString() + "]");
    //    if (BaseType.BaseType!=null)
    //      sb.Append(" of " + BaseType.ToString());
    //  }
    //  return sb.ToString();
    //}
  
  }

  ///// <summary>
  ///// Konwerter tekstowy formatu tekstowego
  ///// </summary>
  //public partial class VectorValueConverter : TypeConverter
  //{
  //  /// <summary>
  //  /// Konwersja z postaci tekstowej dozwolona
  //  /// </summary>
  //  public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
  //  {
  //    if (sourceType == typeof(string))
  //      return true;
  //    else
  //      return base.CanConvertFrom(context, sourceType);
  //  }

  //  /// <summary>
  //  /// Konwersja do postaci tekstowej dozwolona
  //  /// </summary>
  //  public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
  //  {
  //    if (!(destinationType == typeof(string)))
  //    {
  //      return base.CanConvertTo(context, destinationType);
  //    }
  //    if ((context != null))
  //    {
  //      if (context.PropertyDescriptor != null)
  //      {
  //        return true;
  //      }
  //      return false;
  //    }
  //    return base.CanConvertTo(context, destinationType);
  //  }

  //  /// <summary>
  //  /// Konwersja z postaci tekstowej
  //  /// </summary>
  //  public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object VectorValue)
  //  {
  //    if (VectorValue is string)
  //    {
  //      if ((context != null))
  //      {
  //        Property property = context.Instance as Property;
  //        if (property != null && property.Type != null)
  //        {
  //          VectorValue result = VectorValue.Parse(VectorValue as string, (VectorValue)property.Type);
  //          return result;
  //        }
  //      }
  //    }
  //    return base.ConvertFrom(context, culture, VectorValue);
  //  }

  //  /// <summary>
  //  /// Konwersja do postaci tekstowej
  //  /// </summary>
  //  public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object VectorValue, Type destinationType)
  //  {
  //    if (destinationType == typeof(string) && VectorValue is VectorValue)
  //    {
  //      VectorValue val = (VectorValue)VectorValue;
  //      return val.ToString();
  //    }
  //    return base.ConvertTo(context, culture, VectorValue, destinationType);
  //  }
  //}
}

