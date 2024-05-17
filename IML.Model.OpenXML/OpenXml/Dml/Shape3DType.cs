using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("shape3D")]
  [Alias("Shape3D")]
  public class Shape3DType
  {
    [Tag("coordinate")]
    CoordinateValue Z{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue ExtrusionH{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue ContourW{ get; set; }

    [Tag("presetMaterialType")]
    PresetMaterialTypeValues PrstMaterial{ get; set; }

  }
}
