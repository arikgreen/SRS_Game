using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(-5399999)]
  [MaxValue(5399999)]
  [Alias("FixedAngle")]
  public struct FixedAngleValue
  {
    private Int32 value;

    private FixedAngleValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator FixedAngleValue (Int32 value)
    {
      return new FixedAngleValue(value);
    }

    public static implicit operator Int32 (FixedAngleValue value)
    {
      return value.value;
    }

  }
}
