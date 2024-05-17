using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("pt")]
  [Alias("Pt")]
  public class Point
  {
    [Tag("modelId")]
    ModelIdValue ModelId{ get; set; }

    [Tag("ptType")]
    PointValues Type{ get; set; }

    [Tag("modelId")]
    ModelIdValue CxnId{ get; set; }

  }
}
