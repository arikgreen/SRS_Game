using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("scatterStyle")]
  [Alias("ScatterStyle")]
  public class ScatterStyle
  {
    [Tag("scatterStyle")]
    ScatterStyleValues Val{ get; set; }

  }
}
