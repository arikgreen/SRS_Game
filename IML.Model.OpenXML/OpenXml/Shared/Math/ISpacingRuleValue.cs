using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [MinValue(0)]
  [MaxValue(4)]
  [Alias("SpacingRule")]
  public interface ISpacingRuleValue
  {
    Int32 AsInt32{ get; set; }

  }
}
