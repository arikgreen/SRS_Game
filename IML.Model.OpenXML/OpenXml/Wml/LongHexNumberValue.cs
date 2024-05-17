using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Format("X8")]
  [Alias("LongHexNumber")]
  public struct LongHexNumberValue
  {
    private UInt32 value;

    private LongHexNumberValue (UInt32 value)
    {
      this.value = value;
    }

    public UInt32 AsUInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator LongHexNumberValue (UInt32 value)
    {
      return new LongHexNumberValue(value);
    }

    public static implicit operator UInt32 (LongHexNumberValue value)
    {
      return value.value;
    }

  }
}
