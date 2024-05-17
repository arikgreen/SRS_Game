using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("extension")]
  [Alias("Extension")]
  public class Extension
  {
    [Token]
    [Tag("token")]
    String Uri{ get; set; }

  }
}
