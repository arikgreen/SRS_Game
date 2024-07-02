using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PositiveCoordinate")]
  public interface IPositiveCoordinateValue
  {
    Int64 AsInt64{ get; set; }

  }
}
