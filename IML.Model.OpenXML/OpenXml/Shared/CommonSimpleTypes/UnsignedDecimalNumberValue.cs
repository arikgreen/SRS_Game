using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Alias("UnsignedDecimalNumber")]
  public struct UnsignedDecimalNumberValue
  {
    private UInt64 value;

    private UnsignedDecimalNumberValue (UInt64 value)
    {
      this.value = value;
    }

    public UInt64 AsUInt64
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator UnsignedDecimalNumberValue (UInt64 value)
    {
      return new UnsignedDecimalNumberValue(value);
    }

    public static implicit operator UInt64 (UnsignedDecimalNumberValue value)
    {
      return value.value;
    }

  }
}
