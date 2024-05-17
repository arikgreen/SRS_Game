using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Pattern(@"0*(600|([0-5]?[0-9]?[0-9]))%")]
  [Units(new string[]{"%"})]
  [Alias("TextScalePercent")]
  public struct TextScalePercentValue
  {
    private Int32 value;

    private TextScalePercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextScalePercentValue (Int32 value)
    {
      return new TextScalePercentValue(value);
    }

    public static implicit operator Int32 (TextScalePercentValue value)
    {
      return value.value;
    }

  }
}
