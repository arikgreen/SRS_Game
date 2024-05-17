using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Union]
  [Alias("GapAmount")]
  public struct GapAmountValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private GapAmountValue (GapAmountPercentValue value)
    {
      this.value = value;
    }

    public GapAmountPercentValue AsGapAmountPercentValue
    {
      get
      {
        return (GapAmountPercentValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator GapAmountValue (GapAmountPercentValue value)
    {
      return new GapAmountValue(value);
    }

    public static implicit operator GapAmountPercentValue (GapAmountValue value)
    {
      return (GapAmountPercentValue)value.value;
    }

  }
}
