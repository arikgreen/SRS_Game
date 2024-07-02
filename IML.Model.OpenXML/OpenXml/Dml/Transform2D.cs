using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("transform2D")]
  [Alias("Transform2D")]
  public class Transform2D
  {
    [Tag("angle")]
    AngleValue Rot{ get; set; }

    [Tag("boolean")]
    Boolean FlipH{ get; set; }

    [Tag("boolean")]
    Boolean FlipV{ get; set; }

  }
}
