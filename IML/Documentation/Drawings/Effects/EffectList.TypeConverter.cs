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

  [TypeConverter(typeof(EffectListTypeConverter))]
  public partial class EffectList
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static EffectList Parse (string str)
    {
      EffectList result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse EffectList from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out EffectList value)
    {
      value = new EffectList();
      str = str.TryTrimListSeparators();
      string[] ss = FormatHelper.SplitList(str);
      foreach (string s in ss)
      {
        int k = s.IndexOf('(');
        if (k > 0)
        {
          string className = s.Substring(0, k);
          string classDecl = s.Substring(k).TryTrimListSeparators();
          Type classType = Assembly.GetExecutingAssembly().GetType(value.GetType().Namespace
          + "." + className);
          if (classType != null)
          {
            object item;
            if (FormatHelper.TryParse(classDecl, classType, out item))
              value.Add((Effect)item);
            else
              return false;
          }
          else
            return false;
        }
        else
          return false;
      }
      return true;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("(");
      int n = 0;
      foreach (Effect item in this)
      {
        if (n++ != 0)
          sb.Append(", ");
        sb.Append(item.GetType().Name);
        sb.Append("(");
        sb.Append(FormatHelper.ToString(item));
        sb.Append(")");
      }
      sb.Append(")");
      string result = sb.ToString();
      return result;
    }

  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class EffectListTypeConverter : TypeConverter
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
      if (context.PropertyDescriptor.PropertyType == typeof(Effects))
      {
        return true;
      }
      return false;//throw new ArgumentException("EffectList instance expected");
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
      if (context.PropertyDescriptor.PropertyType == typeof(EffectList))
      {
        return true;
      }
      return false;//throw new ArgumentException("EffectList instance expected");
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        EffectList val;
        if (EffectList.TryParse(value as String, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if ((destinationType != null) && (value is EffectList))
      {
        EffectList val = (EffectList)value;
        if (destinationType == typeof(string))
        {
          return val.ToString();
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);

    }
  }
}

