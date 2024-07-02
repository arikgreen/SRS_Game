using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  [TypeConverter(typeof(TrueFalseValueTypeConverter))]
  public partial class TrueFalseValue
  {
  }

  /// <summary>
  /// Konwerter koloru z/na łańcuch znaków
  /// </summary>
  public partial class TrueFalseValueTypeConverter : ColorTypeConverter
  {

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string s = (string)value;
        TrueFalseValue val;
        if (TrueFalseValue.TryParse(s, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }
  }
}
