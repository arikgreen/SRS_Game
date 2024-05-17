using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Markup;
using System.Xml;
using System.Runtime.Serialization;
using System.Windows.Documents;

namespace Iml.Serialization
{
  public class InlineConverter: TypeConverter
  {
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(String))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    {
      if (value is String)
        return new Run((String)value);
      return base.ConvertFrom(context, culture, value);
    }
  }
}
