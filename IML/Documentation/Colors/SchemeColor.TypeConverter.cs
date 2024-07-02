using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(SchemeColorTypeConverter))]
  public partial class SchemeColor
  {
  }

  /// <summary>
  /// Konwerter koloru z/na łańcuch znaków
  /// </summary>
  public partial class SchemeColorTypeConverter : ColorTypeConverter
  {

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string s = (string)value;
        SchemeColor schemeColor;
        if (SchemeColor.TryParse(s, out schemeColor))
          return schemeColor;
      }
      return base.ConvertFrom(context, culture, value);
    }

  }

}
