using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.ChartDrawing
{
  [Alias("MarkerCoordinate")]
  public interface IMarkerCoordinateValue
  {
    Double AsDouble{ get; set; }

  }
}
