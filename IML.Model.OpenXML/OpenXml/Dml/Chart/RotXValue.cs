using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("RotX")]
  public struct RotXValue
  {
    private SByte value;

    private RotXValue (SByte value)
    {
      this.value = value;
    }

    public SByte AsSByte
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator RotXValue (SByte value)
    {
      return new RotXValue(value);
    }

    public static implicit operator SByte (RotXValue value)
    {
      return value.value;
    }

  }
}
