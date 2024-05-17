using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("algorithm")]
  [Alias("Algorithm")]
  public class Algorithm
  {
    [Tag("algorithmType")]
    AlgorithmValues Type{ get; set; }

    [Tag("unsignedInt")]
    UInt32 Rev{ get; set; }

  }
}
