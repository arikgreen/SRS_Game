using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Union]
  [Alias("PrSetCustVal")]
  public struct PrSetCustValValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private PrSetCustValValue (PercentageValue value)
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

    public static implicit operator PrSetCustValValue (PercentageValue value)
    {
      return new PrSetCustValValue(value);
    }

    public static implicit operator PercentageValue (PrSetCustValValue value)
    {
      return (PercentageValue)value.value;
    }

  }
}
