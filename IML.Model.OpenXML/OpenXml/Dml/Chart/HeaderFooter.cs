using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("headerFooter")]
  [Alias("HeaderFooter")]
  public class HeaderFooter
  {
    [Tag("boolean")]
    Boolean AlignWithMargins{ get; set; }

    [Tag("boolean")]
    Boolean DifferentOddEven{ get; set; }

    [Tag("boolean")]
    Boolean DifferentFirst{ get; set; }

  }
}
