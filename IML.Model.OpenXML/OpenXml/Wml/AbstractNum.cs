using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("abstractNum")]
  [Alias("AbstractNum")]
  public class AbstractNum
  {
    [Tag("decimalNumber")]
    DecimalNumberValue AbstractNumId{ get; set; }

  }
}
