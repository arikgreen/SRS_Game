using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("DrawingElementId")]
  public struct DrawingElementIdValue
  {
    private UInt32 value;

    private DrawingElementIdValue (UInt32 value)
    {
      this.value = value;
    }

    public UInt32 AsUInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator DrawingElementIdValue (UInt32 value)
    {
      return new DrawingElementIdValue(value);
    }

    public static implicit operator UInt32 (DrawingElementIdValue value)
    {
      return value.value;
    }

  }
}
