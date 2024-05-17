using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [MaxValue(10800000)]
  [Alias("FOVAngle")]
  public struct FOVAngleValue
  {
    private Int32 value;

    private FOVAngleValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator FOVAngleValue (Int32 value)
    {
      return new FOVAngleValue(value);
    }

    public static implicit operator Int32 (FOVAngleValue value)
    {
      return value.value;
    }

  }
}
