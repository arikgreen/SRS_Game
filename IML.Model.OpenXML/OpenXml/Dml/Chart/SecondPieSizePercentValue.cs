using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([5-9])|([1-9][0-9])|(1[0-9][0-9])|200)%")]
  [Units(new string[]{"%"})]
  [Alias("SecondPieSizePercent")]
  public struct SecondPieSizePercentValue
  {
    private Int32 value;

    private SecondPieSizePercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator SecondPieSizePercentValue (Int32 value)
    {
      return new SecondPieSizePercentValue(value);
    }

    public static implicit operator Int32 (SecondPieSizePercentValue value)
    {
      return value.value;
    }

  }
}
