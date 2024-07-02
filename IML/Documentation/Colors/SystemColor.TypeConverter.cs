using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(SystemColorTypeConverter))]
  public partial class SystemColor
  {
  }

  /// <summary>
  /// Konwerter koloru z/na łańcuch znaków
  /// </summary>
  public partial class SystemColorTypeConverter : ColorTypeConverter
  {

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string s = (string)value;
        SystemColor systemColor;
        if (SystemColor.TryParse(s, out systemColor))
          return systemColor;
      }
      return base.ConvertFrom(context, culture, value);
    }

  }

}
