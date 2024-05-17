using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"([0-9]+)%")]
  [Units(new string[]{"%"})]
  [Alias("ThicknessPercent")]
  public struct ThicknessPercentValue
  {
    private Int32 value;

    private ThicknessPercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator ThicknessPercentValue (Int32 value)
    {
      return new ThicknessPercentValue(value);
    }

    public static implicit operator Int32 (ThicknessPercentValue value)
    {
      return value.value;
    }

  }
}
