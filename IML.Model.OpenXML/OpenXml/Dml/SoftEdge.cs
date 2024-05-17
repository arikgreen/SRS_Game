using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("softEdgesEffect")]
  [Alias("SoftEdgesEffect")]
  public class SoftEdge
  {
    [Tag("positiveCoordinate")]
    PositiveCoordinateValue Rad{ get; set; }

  }
}
