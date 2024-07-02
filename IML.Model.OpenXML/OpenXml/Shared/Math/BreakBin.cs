using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("breakBin")]
  [Alias("BreakBin")]
  public class BreakBin
  {
    [Tag("breakBin")]
    BreakBinaryOperatorValues Val{ get; set; }

  }
}
