using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("constraint")]
  [Alias("Constraint")]
  public class Constraint
  {
    [Tag("boolOperator")]
    BoolOperatorValues Op{ get; set; }

    [Tag("double")]
    Double Val{ get; set; }

    [Tag("double")]
    Double Fact{ get; set; }

  }
}
