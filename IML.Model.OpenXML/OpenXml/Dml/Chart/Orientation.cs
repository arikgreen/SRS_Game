using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("orientation")]
  [Alias("Orientation")]
  public class Orientation
  {
    [Tag("orientation")]
    OrientationValues Val{ get; set; }

  }
}
