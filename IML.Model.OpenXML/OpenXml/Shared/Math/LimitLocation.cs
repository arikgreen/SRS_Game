using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("limLoc")]
  [Alias("LimLoc")]
  public class LimitLocation
  {
    [Tag("limLoc")]
    LimitLocationValues Val{ get; set; }

  }
}
