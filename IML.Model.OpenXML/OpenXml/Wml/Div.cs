using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("div")]
  [Alias("Div")]
  public class Div
  {
    [Tag("decimalNumber")]
    DecimalNumberValue Id{ get; set; }

  }
}
