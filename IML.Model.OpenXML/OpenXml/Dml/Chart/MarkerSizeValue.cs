using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("MarkerSize")]
  public struct MarkerSizeValue
  {
    private Byte value;

    private MarkerSizeValue (Byte value)
    {
      this.value = value;
    }

    public Byte AsByte
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator MarkerSizeValue (Byte value)
    {
      return new MarkerSizeValue(value);
    }

    public static implicit operator Byte (MarkerSizeValue value)
    {
      return value.value;
    }

  }
}
