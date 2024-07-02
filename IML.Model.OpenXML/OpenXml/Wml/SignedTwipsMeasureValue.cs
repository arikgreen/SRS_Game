using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Union]
  [Alias("SignedTwipsMeasure")]
  public struct SignedTwipsMeasureValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private SignedTwipsMeasureValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get
      {
        return (Int32)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator SignedTwipsMeasureValue (Int32 value)
    {
      return new SignedTwipsMeasureValue(value);
    }

    public static implicit operator Int32 (SignedTwipsMeasureValue value)
    {
      return (Int32)value.value;
    }

    private SignedTwipsMeasureValue (UniversalMeasureValue value)
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

    public static implicit operator SignedTwipsMeasureValue (UniversalMeasureValue value)
    {
      return new SignedTwipsMeasureValue(value);
    }

    public static implicit operator UniversalMeasureValue (SignedTwipsMeasureValue value)
    {
      return (UniversalMeasureValue)value.value;
    }

  }
}
