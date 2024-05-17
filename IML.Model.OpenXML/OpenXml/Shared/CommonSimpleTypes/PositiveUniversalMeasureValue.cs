using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Pattern(@"-?[0-9]+(\.[0-9]+)?(mm|cm|in|pt|pc|pi)")]
  [Units(new string[]{"mm","cm","in","pt","pc","pi"})]
  [Alias("PositiveUniversalMeasure")]
  public struct PositiveUniversalMeasureValue
  {
    private Double value;

    private PositiveUniversalMeasureValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PositiveUniversalMeasureValue (Double value)
    {
      return new PositiveUniversalMeasureValue(value);
    }

    public static implicit operator Double (PositiveUniversalMeasureValue value)
    {
      return value.value;
    }

  }
}
