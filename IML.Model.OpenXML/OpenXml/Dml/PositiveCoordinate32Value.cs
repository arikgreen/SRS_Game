using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [Alias("PositiveCoordinate32")]
  public struct PositiveCoordinate32Value
  {
    private Int32 value;

    private PositiveCoordinate32Value (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PositiveCoordinate32Value (Int32 value)
    {
      return new PositiveCoordinate32Value(value);
    }

    public static implicit operator Int32 (PositiveCoordinate32Value value)
    {
      return value.value;
    }

  }
}
