using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("num")]
  [Alias("Num")]
  public class NumberingInstance
  {
    [Tag("decimalNumber")]
    DecimalNumberValue NumId{ get; set; }

  }
}
