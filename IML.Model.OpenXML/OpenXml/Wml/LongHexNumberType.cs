using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("longHexNumber")]
  [Alias("LongHexNumber")]
  public class LongHexNumberType
  {
    [Tag("longHexNumber")]
    LongHexNumberValue Val{ get; set; }

  }
}
