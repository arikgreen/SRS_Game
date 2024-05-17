using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Pattern(@"-?[0-9]+(\.[0-9]+)?%")]
  [Units(new string[]{"%"})]
  [Alias("FixedPercentage")]
  public struct FixedPercentageValue
  {
    private Double value;

    private FixedPercentageValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator FixedPercentageValue (Double value)
    {
      return new FixedPercentageValue(value);
    }

    public static implicit operator Double (FixedPercentageValue value)
    {
      return value.value;
    }

  }
}
