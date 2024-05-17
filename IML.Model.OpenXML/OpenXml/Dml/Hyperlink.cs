using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("hyperlink")]
  [Alias("Hyperlink")]
  public class Hyperlink
  {
    [Tag("string")]
    String InvalidUrl{ get; set; }

    [Tag("string")]
    String Action{ get; set; }

    [Tag("string")]
    String TgtFrame{ get; set; }

    [Tag("string")]
    String Tooltip{ get; set; }

    [Tag("boolean")]
    Boolean History{ get; set; }

    [Tag("boolean")]
    Boolean HighlightClick{ get; set; }

    [Tag("boolean")]
    Boolean EndSnd{ get; set; }

  }
}
