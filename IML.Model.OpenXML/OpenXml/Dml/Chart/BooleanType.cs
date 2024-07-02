using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("boolean")]
  [Alias("Boolean")]
  public class BooleanType
  {
    [Tag("boolean")]
    Boolean Val{ get; set; }

  }
}
