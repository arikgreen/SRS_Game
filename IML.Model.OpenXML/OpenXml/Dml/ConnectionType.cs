using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("connection")]
  [Alias("Connection")]
  public class ConnectionType
  {
    [Tag("drawingElementId")]
    DrawingElementIdValue Id{ get; set; }

    [Tag("unsignedInt")]
    UInt32 Idx{ get; set; }

  }
}
