using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([0-9])|([1-9][0-9])|([1-2][0-9][0-9])|300)%")]
  [Units(new string[]{"%"})]
  [Alias("BubbleScalePercent")]
  public struct BubbleScalePercentValue
  {
    private Int32 value;

    private BubbleScalePercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator BubbleScalePercentValue (Int32 value)
    {
      return new BubbleScalePercentValue(value);
    }

    public static implicit operator Int32 (BubbleScalePercentValue value)
    {
      return value.value;
    }

  }
}
