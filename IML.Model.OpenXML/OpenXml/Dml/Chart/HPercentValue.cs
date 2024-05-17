using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Union]
  [Alias("HPercent")]
  public struct HPercentValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private HPercentValue (HPercentWithSymbolValue value)
    {
      this.value = value;
    }

    public HPercentWithSymbolValue AsHPercentWithSymbolValue
    {
      get
      {
        return (HPercentWithSymbolValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator HPercentValue (HPercentWithSymbolValue value)
    {
      return new HPercentValue(value);
    }

    public static implicit operator HPercentWithSymbolValue (HPercentValue value)
    {
      return (HPercentWithSymbolValue)value.value;
    }

  }
}
