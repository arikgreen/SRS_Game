using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [MaxValue(20116800)]
  [Alias("LineWidth")]
  public struct LineWidthValue
  {
    private Int32 value;

    private LineWidthValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator LineWidthValue (Int32 value)
    {
      return new LineWidthValue(value);
    }

    public static implicit operator Int32 (LineWidthValue value)
    {
      return value.value;
    }

  }
}
