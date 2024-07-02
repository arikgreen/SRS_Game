using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("axPos")]
  [Alias("AxPos")]
  public class AxisPosition
  {
    [Tag("axPos")]
    AxisPositionValues Val{ get; set; }

  }
}
