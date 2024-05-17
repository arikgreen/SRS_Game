using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Pattern(@"-?[0-9]+(\.[0-9]+)?%")]
  [Units(new string[]{"%"})]
  [Alias("PositiveFixedPercentage")]
  public struct PositiveFixedPercentageValue
  {
    private Double value;

    private PositiveFixedPercentageValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PositiveFixedPercentageValue (Double value)
    {
      return new PositiveFixedPercentageValue(value);
    }

    public static implicit operator Double (PositiveFixedPercentageValue value)
    {
      return value.value;
    }

  }
}
