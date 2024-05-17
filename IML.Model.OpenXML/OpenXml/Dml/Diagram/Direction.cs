using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("direction")]
  [Alias("Direction")]
  public class Direction
  {
    [Tag("direction")]
    DirectionValues Val{ get; set; }

  }
}
