using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("graphicalObjectData")]
  [Alias("GraphicalObjectData")]
  public class GraphicData
  {
    [Token]
    [Tag("token")]
    String Uri{ get; set; }

  }
}
