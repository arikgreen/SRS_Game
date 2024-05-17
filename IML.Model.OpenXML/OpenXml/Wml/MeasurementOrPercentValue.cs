using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Union]
  [Alias("MeasurementOrPercent")]
  public struct MeasurementOrPercentValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private MeasurementOrPercentValue (DecimalNumberOrPercentValue value)
    {
      this.value = value;
    }

    public DecimalNumberOrPercentValue AsDecimalNumberOrPercentValue
    {
      get
      {
        return (DecimalNumberOrPercentValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator MeasurementOrPercentValue (DecimalNumberOrPercentValue value)
    {
      return new MeasurementOrPercentValue(value);
    }

    public static implicit operator DecimalNumberOrPercentValue (MeasurementOrPercentValue value)
    {
      return (DecimalNumberOrPercentValue)value.value;
    }

    private MeasurementOrPercentValue (UniversalMeasureValue value)
    {
      this.value = value;
    }

    public UniversalMeasureValue AsUniversalMeasureValue
    {
      get
      {
        return (UniversalMeasureValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator MeasurementOrPercentValue (UniversalMeasureValue value)
    {
      return new MeasurementOrPercentValue(value);
    }

    public static implicit operator UniversalMeasureValue (MeasurementOrPercentValue value)
    {
      return (UniversalMeasureValue)value.value;
    }

  }
}
