using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Format("X4")]
  [Alias("ShortHexNumber")]
  public struct ShortHexNumberValue
  {
    private UInt16 value;

    private ShortHexNumberValue (UInt16 value)
    {
      this.value = value;
    }

    public UInt16 AsUInt16
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator ShortHexNumberValue (UInt16 value)
    {
      return new ShortHexNumberValue(value);
    }

    public static implicit operator UInt16 (ShortHexNumberValue value)
    {
      return value.value;
    }

  }
}
