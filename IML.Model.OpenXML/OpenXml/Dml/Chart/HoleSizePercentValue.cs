using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*([1-9]|([1-8][0-9])|90)%")]
  [Units(new string[]{"%"})]
  [Alias("HoleSizePercent")]
  public struct HoleSizePercentValue
  {
    private Int32 value;

    private HoleSizePercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator HoleSizePercentValue (Int32 value)
    {
      return new HoleSizePercentValue(value);
    }

    public static implicit operator Int32 (HoleSizePercentValue value)
    {
      return value.value;
    }

  }
}
