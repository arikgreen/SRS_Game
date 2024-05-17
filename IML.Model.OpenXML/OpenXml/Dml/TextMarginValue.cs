using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [MaxValue(51206400)]
  [Alias("TextMargin")]
  public struct TextMarginValue
  {
    private Int32 value;

    private TextMarginValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextMarginValue (Int32 value)
    {
      return new TextMarginValue(value);
    }

    public static implicit operator Int32 (TextMarginValue value)
    {
      return value.value;
    }

  }
}
