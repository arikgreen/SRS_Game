using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("verticalJc")]
  [Alias("VerticalJc")]
  public class VerticalJc
  {
    [Tag("verticalJc")]
    VerticalJustificationValues Val{ get; set; }

  }
}
