using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("gapAmount")]
  [Alias("GapAmount")]
  public class GapAmountType
  {
    [Tag("gapAmount")]
    GapAmountValue Val{ get; set; }

  }
}
