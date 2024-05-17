using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("pageMargins")]
  [Alias("PageMargins")]
  public class PageMargins
  {
    [Tag("double")]
    Double L{ get; set; }

    [Tag("double")]
    Double R{ get; set; }

    [Tag("double")]
    Double T{ get; set; }

    [Tag("double")]
    Double B{ get; set; }

    [Tag("double")]
    Double Header{ get; set; }

    [Tag("double")]
    Double Footer{ get; set; }

  }
}
