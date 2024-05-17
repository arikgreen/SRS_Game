using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("breakBinSub")]
  [Alias("BreakBinSub")]
  public class BreakBinSub
  {
    [Tag("breakBinSub")]
    BreakBinarySubtractionValues Val{ get; set; }

  }
}
