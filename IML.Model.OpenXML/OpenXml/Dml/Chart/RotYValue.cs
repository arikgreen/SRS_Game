using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("RotY")]
  public struct RotYValue
  {
    private UInt16 value;

    private RotYValue (UInt16 value)
    {
      this.value = value;
    }

    public UInt16 AsUInt16
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator RotYValue (UInt16 value)
    {
      return new RotYValue(value);
    }

    public static implicit operator UInt16 (RotYValue value)
    {
      return value.value;
    }

  }
}
