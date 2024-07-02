using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("decimalNumberOrPrecent")]
  [Alias("DecimalNumberOrPrecent")]
  public class DecimalNumberOrPercentValue
  {
    [Tag("decimalNumberOrPercent")]
    DecimalNumberOrPercentValue Val{ get; set; }

  }
}
