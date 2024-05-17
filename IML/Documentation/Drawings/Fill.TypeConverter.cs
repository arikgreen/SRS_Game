using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Iml.Documentation.Drawings
{

  [TypeConverter(typeof(FillTypeConverter))]
  public partial class Fill
  {
    /// <summary>
    /// Czy może być serializowane do łańcucha
    /// </summary>
    /// <returns></returns>
    public abstract bool CanSerializeToString ();
  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class FillTypeConverter : TypeConverter
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
      if (!(context.Instance is Fill))
      {
        return false;
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
      if (context.Instance != null && 
        context.PropertyDescriptor!=null &&  context.PropertyDescriptor.PropertyType == typeof(Fill))
      {
        Fill value = context.PropertyDescriptor.GetValue(context.Instance) as Fill;
        if (value != null)
          return value.CanSerializeToString();
      }
      return false;
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string s = value as String;
        NoFill noFill;
        if (NoFill.TryParse(value as String, out noFill))
          return noFill;

        SolidFill solidFill;
        if (SolidFill.TryParse(s, out solidFill))
          return solidFill;

        PathGradientFill PathGradientFill;
        if (PathGradientFill.TryParse(s, out PathGradientFill))
          return PathGradientFill;

        LinearGradientFill LinearGradientFill;
        if (LinearGradientFill.TryParse(s, out LinearGradientFill))
          return LinearGradientFill;

        PictureFill PictureFill;
        if (PictureFill.TryParse(s, out PictureFill))
          return PictureFill;      
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if ((destinationType != null) && (value is Fill))
      {
        Fill val = (Fill)value;
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

