using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("Percentage")]
  public struct PercentageValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private PercentageValue (PercentageValue value)
    {
      this.value = value;
    }

    public PercentageValue AsPercentageValue
    {
      get
      {
        return (PercentageValue)value;
      }
      set
      {
        this.value = value;
      }
    }

  }
}
