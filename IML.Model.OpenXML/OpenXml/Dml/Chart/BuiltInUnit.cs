using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("builtInUnit")]
  [Alias("BuiltInUnit")]
  public class BuiltInUnit
  {
    [Tag("builtInUnit")]
    BuiltInUnitValues Val{ get; set; }

  }
}
