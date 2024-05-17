using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Union]
  [Alias("HpsMeasure")]
  public struct HpsMeasureValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private HpsMeasureValue (UnsignedDecimalNumberValue value)
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

    public static implicit operator HpsMeasureValue (UnsignedDecimalNumberValue value)
    {
      return new HpsMeasureValue(value);
    }

    public static implicit operator UnsignedDecimalNumberValue (HpsMeasureValue value)
    {
      return (UnsignedDecimalNumberValue)value.value;
    }

    private HpsMeasureValue (PositiveUniversalMeasureValue value)
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

    public static implicit operator HpsMeasureValue (PositiveUniversalMeasureValue value)
    {
      return new HpsMeasureValue(value);
    }

    public static implicit operator PositiveUniversalMeasureValue (HpsMeasureValue value)
    {
      return (PositiveUniversalMeasureValue)value.value;
    }

  }
}
