using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Iml.Foundation
{
  /// <summary>
  /// Konwerter referencji do/z postaci tekstowej.
  /// Podaje <c>TargetID</c> referencji.
  /// </summary>
  public partial class ReferenceTypeConverter: TypeConverter
  {
    /// <summary>
    /// Konwersja z postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(string))
        return true;
      else
        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof(string))
        return true;
      else
        return base.CanConvertFrom(context, destinationType);
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string s = value as string;
        Guid id;
        if (Guid.TryParse(s, out id))
          return new Reference { TargetID = id };
        if (RefIDGenerator.IsRefID (s))
          return new Reference { TargetRefID = s };
        return new Reference { TargetName = s };
      }
      else
        return base.ConvertFrom (context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is Reference)
        return (value as Reference).TargetID.ToString();
      else
        return base.ConvertTo(context, culture, value, destinationType);
    }

  }
}
