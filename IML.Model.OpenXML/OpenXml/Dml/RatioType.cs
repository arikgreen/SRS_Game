using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("ratio")]
  [Alias("Ratio")]
  public class RatioType
  {
    [Tag("long")]
    Int64 N{ get; set; }

    [Tag("long")]
    Int64 D{ get; set; }

  }
}
