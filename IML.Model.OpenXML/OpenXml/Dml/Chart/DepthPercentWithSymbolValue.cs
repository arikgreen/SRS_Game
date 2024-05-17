using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([2-9][0-9])|([1-9][0-9][0-9])|(1[0-9][0-9][0-9])|2000)%")]
  [Units(new string[]{"%"})]
  [Alias("DepthPercentWithSymbol")]
  public struct DepthPercentWithSymbolValue
  {
    private Int32 value;

    private DepthPercentWithSymbolValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator DepthPercentWithSymbolValue (Int32 value)
    {
      return new DepthPercentWithSymbolValue(value);
    }

    public static implicit operator Int32 (DepthPercentWithSymbolValue value)
    {
      return value.value;
    }

  }
}
