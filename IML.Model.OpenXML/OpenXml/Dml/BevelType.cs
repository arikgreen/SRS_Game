using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("bevel")]
  [Alias("Bevel")]
  public class BevelType
  {
    [Tag("positiveCoordinate")]
    PositiveCoordinateValue W{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue H{ get; set; }

    [Tag("bevelPresetType")]
    BevelPresetValues Prst{ get; set; }

  }
}
