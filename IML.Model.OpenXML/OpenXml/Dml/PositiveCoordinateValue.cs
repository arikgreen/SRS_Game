using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PositiveCoordinate")]
  public struct PositiveCoordinateValue
  {
    private Int64 value;

    private PositiveCoordinateValue (Int64 value)
    {
      this.value = value;
    }

    public Int64 AsInt64
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PositiveCoordinateValue (Int64 value)
    {
      return new PositiveCoordinateValue(value);
    }

    public static implicit operator Int64 (PositiveCoordinateValue value)
    {
      return value.value;
    }

  }
}
