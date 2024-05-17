using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("PositivePercentage")]
  public struct PositivePercentageValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private PositivePercentageValue (PositivePercentageValue value)
    {
      this.value = value;
    }

    public PositivePercentageValue AsPositivePercentageValue
    {
      get
      {
        return (PositivePercentageValue)value;
      }
      set
      {
        this.value = value;
      }
    }

  }
}
