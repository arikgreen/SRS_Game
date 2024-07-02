using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([0-9])|([1-9][0-9])|([1-9][0-9][0-9])|1000)%")]
  [Units(new string[]{"%"})]
  [Alias("LblOffsetPercent")]
  public struct LblOffsetPercentValue
  {
    private Int32 value;

    private LblOffsetPercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator LblOffsetPercentValue (Int32 value)
    {
      return new LblOffsetPercentValue(value);
    }

    public static implicit operator Int32 (LblOffsetPercentValue value)
    {
      return value.value;
    }

  }
}
