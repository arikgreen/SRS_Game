using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("PositiveFixedPercentage")]
  public struct PositiveFixedPercentageValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private PositiveFixedPercentageValue (PositiveFixedPercentageValue value)
    {
      this.value = value;
    }

    public PositiveFixedPercentageValue AsPositiveFixedPercentageValue
    {
      get
      {
        return (PositiveFixedPercentageValue)value;
      }
      set
      {
        this.value = value;
      }
    }

  }
}
