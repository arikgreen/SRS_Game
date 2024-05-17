using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("colors")]
  [Alias("Colors")]
  public class ColorsType
  {
    [Tag("clrAppMethod")]
    ColorApplicationMethodValues Meth{ get; set; }

    [Tag("hueDir")]
    FlowDirectionValues HueDir{ get; set; }

  }
}
