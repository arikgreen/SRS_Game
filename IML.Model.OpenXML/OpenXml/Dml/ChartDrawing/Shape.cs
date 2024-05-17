using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.ChartDrawing
{
  [Tag("shape")]
  [Alias("Shape")]
  public class Shape
  {
    [Tag("string")]
    String Macro{ get; set; }

    [Tag("string")]
    String Textlink{ get; set; }

    [Tag("boolean")]
    Boolean FLocksText{ get; set; }

    [Tag("boolean")]
    Boolean FPublished{ get; set; }

  }
}
