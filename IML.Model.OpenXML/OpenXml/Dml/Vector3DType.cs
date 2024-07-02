using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("vector3D")]
  [Alias("Vector3D")]
  public class Vector3DType
  {
    [Tag("coordinate")]
    CoordinateValue Dx{ get; set; }

    [Tag("coordinate")]
    CoordinateValue Dy{ get; set; }

    [Tag("coordinate")]
    CoordinateValue Dz{ get; set; }

  }
}
