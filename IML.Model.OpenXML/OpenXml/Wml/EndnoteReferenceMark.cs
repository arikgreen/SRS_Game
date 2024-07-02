using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("ftnEdnSepRef")]
  [Alias("FtnEdnSepRef")]
  public class EndnoteReferenceMark
  {
    [Tag("decimalNumber")]
    DecimalNumberValue Id{ get; set; }

  }
}
