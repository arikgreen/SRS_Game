using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("unsignedDecimalNumber")]
  [Alias("UnsignedDecimalNumber")]
  public class UnsignedDecimalNumberType
  {
    [Tag("unsignedDecimalNumber")]
    UnsignedDecimalNumberValue Val{ get; set; }

  }
}
