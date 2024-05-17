using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Format("X6")]
  [Alias("HexColorRGB")]
  public struct HexColorRGBValue
  {
    private UInt32 value;

    private HexColorRGBValue (UInt32 value)
    {
      this.value = value;
    }

    public UInt32 AsUInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator HexColorRGBValue (UInt32 value)
    {
      return new HexColorRGBValue(value);
    }

    public static implicit operator UInt32 (HexColorRGBValue value)
    {
      return value.value;
    }

  }
}
