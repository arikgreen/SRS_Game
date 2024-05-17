using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Pattern(@"0*(([5-9])|([1-9][0-9])|([1-4][0-9][0-9])|500)%")]
  [Units(new string[]{"%"})]
  [Alias("HPercentWithSymbol")]
  public struct HPercentWithSymbolValue
  {
    private Int32 value;

    private HPercentWithSymbolValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator HPercentWithSymbolValue (Int32 value)
    {
      return new HPercentWithSymbolValue(value);
    }

    public static implicit operator Int32 (HPercentWithSymbolValue value)
    {
      return value.value;
    }

  }
}
