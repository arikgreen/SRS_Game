using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("hyperlink")]
  [Alias("Hyperlink")]
  public class Hyperlink
  {
    [Tag("string")]
    String TgtFrame{ get; set; }

    [Tag("string")]
    String Tooltip{ get; set; }

    [Tag("string")]
    String DocLocation{ get; set; }

    [Tag("onOff")]
    OnOffValue History{ get; set; }

    [Tag("string")]
    String Anchor{ get; set; }

  }
}
