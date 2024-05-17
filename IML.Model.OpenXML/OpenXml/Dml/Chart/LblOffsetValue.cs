using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Union]
  [Alias("LblOffset")]
  public struct LblOffsetValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private LblOffsetValue (LblOffsetPercentValue value)
    {
      this.value = value;
    }

    public LblOffsetPercentValue AsLblOffsetPercentValue
    {
      get
      {
        return (LblOffsetPercentValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator LblOffsetValue (LblOffsetPercentValue value)
    {
      return new LblOffsetValue(value);
    }

    public static implicit operator LblOffsetPercentValue (LblOffsetValue value)
    {
      return (LblOffsetPercentValue)value.value;
    }

  }
}
