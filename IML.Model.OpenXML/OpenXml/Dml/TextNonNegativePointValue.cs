using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextNonNegativePoint")]
  public struct TextNonNegativePointValue
  {
    private Int32 value;

    private TextNonNegativePointValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextNonNegativePointValue (Int32 value)
    {
      return new TextNonNegativePointValue(value);
    }

    public static implicit operator Int32 (TextNonNegativePointValue value)
    {
      return value.value;
    }

  }
}
