using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("manualBreak")]
  [Alias("ManualBreak")]
  public class NoBreak
  {
    [Tag("integer255")]
    Integer255Value AlnAt{ get; set; }

  }
}
