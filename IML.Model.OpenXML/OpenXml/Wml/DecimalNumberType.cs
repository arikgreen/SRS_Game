using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("decimalNumber")]
  [Alias("DecimalNumber")]
  public class DecimalNumberType
  {
    [Tag("decimalNumber")]
    DecimalNumberValue Val{ get; set; }

  }
}
