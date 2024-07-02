using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("EighthPointMeasure")]
  public struct EighthPointMeasureValue
  {
    private UInt64 value;

    private EighthPointMeasureValue (UInt64 value)
    {
      this.value = value;
    }

    public UInt64 AsUInt64
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator EighthPointMeasureValue (UInt64 value)
    {
      return new EighthPointMeasureValue(value);
    }

    public static implicit operator UInt64 (EighthPointMeasureValue value)
    {
      return value.value;
    }

  }
}
