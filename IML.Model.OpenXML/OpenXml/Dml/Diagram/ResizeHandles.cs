using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("resizeHandles")]
  [Alias("ResizeHandles")]
  public class ResizeHandles
  {
    [Tag("resizeHandlesStr")]
    ResizeHandlesStringValues Val{ get; set; }

  }
}
