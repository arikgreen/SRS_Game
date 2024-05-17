using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("layoutNode")]
  [Alias("LayoutNode")]
  public class LayoutNode
  {
    [Tag("string")]
    String Name{ get; set; }

    [Tag("string")]
    String StyleLbl{ get; set; }

    [Tag("childOrderType")]
    ChildOrderValues ChOrder{ get; set; }

    [Tag("string")]
    String MoveWith{ get; set; }

  }
}
