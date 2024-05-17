using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("TextFontScalePercentOrPercentString")]
  public struct TextFontScalePercentOrPercentStringValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private TextFontScalePercentOrPercentStringValue (PercentageValue value)
    {
      this.value = value;
    }

    public PercentageValue AsPercentageValue
    {
      get
      {
        return (PercentageValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator TextFontScalePercentOrPercentStringValue (PercentageValue value)
    {
      return new TextFontScalePercentOrPercentStringValue(value);
    }

    public static implicit operator PercentageValue (TextFontScalePercentOrPercentStringValue value)
    {
      return (PercentageValue)value.value;
    }

  }
}
