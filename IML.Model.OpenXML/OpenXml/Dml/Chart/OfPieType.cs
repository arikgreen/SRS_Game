using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("ofPieType")]
  [Alias("OfPieType")]
  public class OfPieType
  {
    [Tag("ofPieType")]
    OfPieValues Val{ get; set; }

  }
}
