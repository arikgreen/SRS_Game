using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("lblAlgn")]
  [Alias("LblAlgn")]
  public class LabelAlignment
  {
    [Tag("lblAlgn")]
    LabelAlignmentValues Val{ get; set; }

  }
}
