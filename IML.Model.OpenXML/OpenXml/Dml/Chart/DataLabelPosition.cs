using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("dLblPos")]
  [Alias("DLblPos")]
  public class DataLabelPosition
  {
    [Tag("dLblPos")]
    DataLabelPositionValues Val{ get; set; }

  }
}
