using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("styleDefinition")]
  [Alias("StyleDefinition")]
  public class StyleDefinition
  {
    [Tag("string")]
    String UniqueId{ get; set; }

    [Tag("string")]
    String MinVer{ get; set; }

  }
}
