using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("WrapDistance")]
  public struct WrapDistanceValue
  {
    private UInt32 value;

    private WrapDistanceValue (UInt32 value)
    {
      this.value = value;
    }

    public UInt32 AsUInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator WrapDistanceValue (UInt32 value)
    {
      return new WrapDistanceValue(value);
    }

    public static implicit operator UInt32 (WrapDistanceValue value)
    {
      return value.value;
    }

  }
}
