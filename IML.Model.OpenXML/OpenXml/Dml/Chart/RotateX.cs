using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("rotX")]
  [Alias("RotX")]
  public class RotateX
  {
    [Tag("rotX")]
    RotXValue Val{ get; set; }

  }
}
