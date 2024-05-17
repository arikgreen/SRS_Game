using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("styleDefinitionHeader")]
  [Alias("StyleDefinitionHeader")]
  public class StyleDefinitionHeader
  {
    [Tag("string")]
    String UniqueId{ get; set; }

    [Tag("string")]
    String MinVer{ get; set; }

    [Tag("int")]
    Int32 ResId{ get; set; }

  }
}
