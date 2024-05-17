using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("adj")]
  [Alias("Adj")]
  public class Adjust
  {
    [Tag("index1")]
    Index1Value Idx{ get; set; }

    [Tag("double")]
    Double Val{ get; set; }

  }
}
