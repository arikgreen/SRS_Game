using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Pattern(@"-?[0-9]+(\.[0-9]+)?%")]
  [Units(new string[]{"%"})]
  [Alias("Percentage")]
  public struct PercentageValue
  {
    private Double value;

    private PercentageValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PercentageValue (Double value)
    {
      return new PercentageValue(value);
    }

    public static implicit operator Double (PercentageValue value)
    {
      return value.value;
    }

  }
}
