using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("rotY")]
  [Alias("RotY")]
  public class RotateY
  {
    [Tag("rotY")]
    RotYValue Val{ get; set; }

  }
}
