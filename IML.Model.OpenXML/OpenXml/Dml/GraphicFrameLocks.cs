using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("groupShapeProperties")]
  [Alias("GroupShapeProperties")]
  public class GraphicFrameLocks
  {
    [Tag("blackWhiteMode")]
    BlackWhiteModeValues BwMode{ get; set; }

  }
}
