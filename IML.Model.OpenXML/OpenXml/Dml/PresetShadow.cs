using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("presetShadowEffect")]
  [Alias("PresetShadowEffect")]
  public class PresetShadow
  {
    [Tag("presetShadowVal")]
    PresetShadowValues Prst{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue Dist{ get; set; }

    [Tag("positiveFixedAngle")]
    PositiveFixedAngleValue Dir{ get; set; }

  }
}
