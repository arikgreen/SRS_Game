using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("strVal")]
  [Alias("StrVal")]
  public class YValues
  {
    [Tag("unsignedInt")]
    UInt32 Idx{ get; set; }

  }
}
