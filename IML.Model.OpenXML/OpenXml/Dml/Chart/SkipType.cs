using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("skip")]
  [Alias("Skip")]
  public class SkipType
  {
    [Tag("skip")]
    SkipValue Val{ get; set; }

  }
}
