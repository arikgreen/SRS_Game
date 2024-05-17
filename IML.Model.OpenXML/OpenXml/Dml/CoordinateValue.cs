using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("Coordinate")]
  public struct CoordinateValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private CoordinateValue (CoordinateUnqualifiedValue value)
    {
      this.value = value;
    }

    public CoordinateUnqualifiedValue AsCoordinateUnqualifiedValue
    {
      get
      {
        return (CoordinateUnqualifiedValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator CoordinateValue (CoordinateUnqualifiedValue value)
    {
      return new CoordinateValue(value);
    }

    public static implicit operator CoordinateUnqualifiedValue (CoordinateValue value)
    {
      return (CoordinateUnqualifiedValue)value.value;
    }

    private CoordinateValue (UniversalMeasureValue value)
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

    public static implicit operator CoordinateValue (UniversalMeasureValue value)
    {
      return new CoordinateValue(value);
    }

    public static implicit operator UniversalMeasureValue (CoordinateValue value)
    {
      return (UniversalMeasureValue)value.value;
    }

  }
}
