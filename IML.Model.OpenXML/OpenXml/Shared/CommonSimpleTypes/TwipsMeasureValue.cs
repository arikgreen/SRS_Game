using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Union]
  [Alias("TwipsMeasure")]
  public struct TwipsMeasureValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private TwipsMeasureValue (UnsignedDecimalNumberValue value)
    {
      this.value = value;
    }

    public UnsignedDecimalNumberValue AsUnsignedDecimalNumberValue
    {
      get
      {
        return (UnsignedDecimalNumberValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator TwipsMeasureValue (UnsignedDecimalNumberValue value)
    {
      return new TwipsMeasureValue(value);
    }

    public static implicit operator UnsignedDecimalNumberValue (TwipsMeasureValue value)
    {
      return (UnsignedDecimalNumberValue)value.value;
    }

    private TwipsMeasureValue (PositiveUniversalMeasureValue value)
    {
      this.value = value;
    }

    public PositiveUniversalMeasureValue AsPositiveUniversalMeasureValue
    {
      get
      {
        return (PositiveUniversalMeasureValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator TwipsMeasureValue (PositiveUniversalMeasureValue value)
    {
      return new TwipsMeasureValue(value);
    }

    public static implicit operator PositiveUniversalMeasureValue (TwipsMeasureValue value)
    {
      return (PositiveUniversalMeasureValue)value.value;
    }

  }
}
