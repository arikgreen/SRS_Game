using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("style")]
  [Alias("Style")]
  public class Style
  {
    [Tag("style")]
    StyleValues Val{ get; set; }

  }
}
