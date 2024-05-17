using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("shapeProperties")]
  [Alias("ShapeProperties")]
  public class ShapeProperties
  {
    [Tag("blackWhiteMode")]
    BlackWhiteModeValues BwMode{ get; set; }

  }
}
