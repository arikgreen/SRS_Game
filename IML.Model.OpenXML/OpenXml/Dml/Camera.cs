using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("camera")]
  [Alias("Camera")]
  public class Camera
  {
    [Tag("presetCameraType")]
    PresetCameraValues Prst{ get; set; }

    [Tag("fOVAngle")]
    FOVAngleValue Fov{ get; set; }

    [Tag("positivePercentage")]
    PositivePercentageValue Zoom{ get; set; }

  }
}
