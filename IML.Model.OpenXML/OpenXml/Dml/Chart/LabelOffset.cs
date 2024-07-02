using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("lblOffset")]
  [Alias("LblOffset")]
  public class LabelOffset
  {
    [Tag("lblOffset")]
    LblOffsetValue Val{ get; set; }

  }
}
