using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Dml.Chart
{
  [Tag("markerSize")]
  [Alias("MarkerSize")]
  public class MarkerStyle
  {
    [Tag("markerSize")]
    MarkerSizeValue Val{ get; set; }

  }
}
