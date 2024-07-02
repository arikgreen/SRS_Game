using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"(-?0*(([0-9])|([1-9][0-9])|100))%")]
  [Units(new string[]{"%"})]
  [Alias("OverlapPercent")]
  public struct OverlapPercentValue
  {
    private Int32 value;

    private OverlapPercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator OverlapPercentValue (Int32 value)
    {
      return new OverlapPercentValue(value);
    }

    public static implicit operator Int32 (OverlapPercentValue value)
    {
      return value.value;
    }

  }
}
