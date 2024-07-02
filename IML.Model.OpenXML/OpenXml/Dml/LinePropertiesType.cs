using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("lineProperties")]
  [Alias("LineProperties")]
  public class LinePropertiesType
  {
    [Tag("lineWidth")]
    LineWidthValue W{ get; set; }

    [Tag("lineCap")]
    LineCapValues Cap{ get; set; }

    [Tag("compoundLine")]
    CompoundLineValues Cmpd{ get; set; }

    [Tag("penAlignment")]
    PenAlignmentValues Algn{ get; set; }

  }
}
