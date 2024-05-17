using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PixelsMeasure")]
  public struct PixelsMeasureValue
  {
    private UInt64 value;

    private PixelsMeasureValue (UInt64 value)
    {
      this.value = value;
    }

    public UInt64 AsUInt64
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PixelsMeasureValue (UInt64 value)
    {
      return new PixelsMeasureValue(value);
    }

    public static implicit operator UInt64 (PixelsMeasureValue value)
    {
      return value.value;
    }

  }
}
