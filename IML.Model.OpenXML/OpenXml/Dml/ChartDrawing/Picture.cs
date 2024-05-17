using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.ChartDrawing
{
  [Tag("picture")]
  [Alias("Picture")]
  public class Picture
  {
    [Tag("string")]
    String Macro{ get; set; }

    [Tag("boolean")]
    Boolean FPublished{ get; set; }

  }
}
