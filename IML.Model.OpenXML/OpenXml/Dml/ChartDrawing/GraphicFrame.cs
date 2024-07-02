using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.ChartDrawing
{
  [Tag("graphicFrame")]
  [Alias("GraphicFrame")]
  public class GraphicFrame
  {
    [Tag("string")]
    String Macro{ get; set; }

    [Tag("boolean")]
    Boolean FPublished{ get; set; }

  }
}
