using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("presetGeometry2D")]
  [Alias("PresetGeometry2D")]
  public class PresetGeometry
  {
    [Tag("shapeType")]
    ShapeTypeValues Prst{ get; set; }

  }
}
