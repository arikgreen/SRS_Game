using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("AxisUnit")]
  public struct AxisUnitValue
  {
    private Double value;

    private AxisUnitValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator AxisUnitValue (Double value)
    {
      return new AxisUnitValue(value);
    }

    public static implicit operator Double (AxisUnitValue value)
    {
      return value.value;
    }

  }
}
