using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("bdoContentRun")]
  [Alias("BdoContentRun")]
  public class Direction
  {
    [Tag("direction")]
    DirectionValues Val{ get; set; }

  }
}
