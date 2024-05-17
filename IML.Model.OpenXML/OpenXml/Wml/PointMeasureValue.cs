using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PointMeasure")]
  public struct PointMeasureValue
  {
    private UInt64 value;

    private PointMeasureValue (UInt64 value)
    {
      this.value = value;
    }

    public UInt64 AsUInt64
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PointMeasureValue (UInt64 value)
    {
      return new PointMeasureValue(value);
    }

    public static implicit operator UInt64 (PointMeasureValue value)
    {
      return value.value;
    }

  }
}
