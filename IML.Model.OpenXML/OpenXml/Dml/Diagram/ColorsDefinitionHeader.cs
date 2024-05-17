using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("diagramDefinitionHeader")]
  [Alias("DiagramDefinitionHeader")]
  public class ColorsDefinitionHeader
  {
    [Tag("string")]
    String UniqueId{ get; set; }

    [Tag("string")]
    String MinVer{ get; set; }

    [Tag("string")]
    String DefStyle{ get; set; }

    [Tag("int")]
    Int32 ResId{ get; set; }

  }
}
