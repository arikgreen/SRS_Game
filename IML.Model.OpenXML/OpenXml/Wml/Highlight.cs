using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("highlight")]
  [Alias("Highlight")]
  public class Highlight
  {
    [Tag("highlightColor")]
    HighlightColorValues Val{ get; set; }

  }
}
