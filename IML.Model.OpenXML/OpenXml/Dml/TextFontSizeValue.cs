using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextFontSize")]
  public struct TextFontSizeValue
  {
    private Int32 value;

    private TextFontSizeValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextFontSizeValue (Int32 value)
    {
      return new TextFontSizeValue(value);
    }

    public static implicit operator Int32 (TextFontSizeValue value)
    {
      return value.value;
    }

  }
}
