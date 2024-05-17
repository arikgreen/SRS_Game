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
  public struct SpacingRuleValue
  {
    private Int32 value;

    private SpacingRuleValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator SpacingRuleValue (Int32 value)
    {
      return new SpacingRuleValue(value);
    }

    public static implicit operator Int32 (SpacingRuleValue value)
    {
      return value.value;
    }

  }
}
