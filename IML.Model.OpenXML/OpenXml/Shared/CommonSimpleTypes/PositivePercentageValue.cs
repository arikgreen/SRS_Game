using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Pattern(@"-?[0-9]+(\.[0-9]+)?%")]
  [Units(new string[]{"%"})]
  [Alias("PositivePercentage")]
  public struct PositivePercentageValue
  {
    private Double value;

    private PositivePercentageValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PositivePercentageValue (Double value)
    {
      return new PositivePercentageValue(value);
    }

    public static implicit operator Double (PositivePercentageValue value)
    {
      return value.value;
    }

  }
}
