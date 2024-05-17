using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("paperSource")]
  [Alias("PaperSource")]
  public class PaperSource
  {
    [Tag("decimalNumber")]
    DecimalNumberValue First{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Other{ get; set; }

  }
}
