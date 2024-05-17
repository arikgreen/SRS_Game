using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("double")]
  [Alias("Double")]
  public class DoubleType
  {
    [Tag("double")]
    Double Val{ get; set; }

  }
}
