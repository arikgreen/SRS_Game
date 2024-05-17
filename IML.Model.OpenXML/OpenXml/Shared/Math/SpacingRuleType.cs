using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("spacingRule")]
  [Alias("SpacingRule")]
  public class SpacingRuleType
  {
    [Tag("spacingRule")]
    SpacingRuleValue Val{ get; set; }

  }
}
