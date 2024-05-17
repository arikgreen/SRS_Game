using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.ChartDrawing
{
  [Alias("MarkerCoordinate")]
  public struct MarkerCoordinateValue
  {
    private Double value;

    private MarkerCoordinateValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator MarkerCoordinateValue (Double value)
    {
      return new MarkerCoordinateValue(value);
    }

    public static implicit operator Double (MarkerCoordinateValue value)
    {
      return value.value;
    }

  }
}
