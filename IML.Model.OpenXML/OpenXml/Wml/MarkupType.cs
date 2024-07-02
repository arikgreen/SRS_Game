using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("markup")]
  [Alias("Markup")]
  public class MarkupType
  {
    [Tag("decimalNumber")]
    DecimalNumberValue Id{ get; set; }

  }
}
