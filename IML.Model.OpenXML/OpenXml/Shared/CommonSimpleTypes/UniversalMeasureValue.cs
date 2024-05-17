using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Pattern(@"-?[0-9]+(\.[0-9]+)?(mm|cm|in|pt|pc|pi)")]
  [Units(new string[]{"mm","cm","in","pt","pc","pi"})]
  [Alias("UniversalMeasure")]
  public struct UniversalMeasureValue
  {
    private Double value;

    private UniversalMeasureValue (Double value)
    {
      this.value = value;
    }

    public Double AsDouble
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator UniversalMeasureValue (Double value)
    {
      return new UniversalMeasureValue(value);
    }

    public static implicit operator Double (UniversalMeasureValue value)
    {
      return value.value;
    }

  }
}
