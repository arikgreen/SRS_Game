using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("Coordinate32")]
  public struct Coordinate32Value
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private Coordinate32Value (Coordinate32UnqualifiedValue value)
    {
      this.value = value;
    }

    public Coordinate32UnqualifiedValue AsCoordinate32UnqualifiedValue
    {
      get
      {
        return (Coordinate32UnqualifiedValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator Coordinate32Value (Coordinate32UnqualifiedValue value)
    {
      return new Coordinate32Value(value);
    }

    public static implicit operator Coordinate32UnqualifiedValue (Coordinate32Value value)
    {
      return (Coordinate32UnqualifiedValue)value.value;
    }

    private Coordinate32Value (UniversalMeasureValue value)
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

    public static implicit operator Coordinate32Value (UniversalMeasureValue value)
    {
      return new Coordinate32Value(value);
    }

    public static implicit operator UniversalMeasureValue (Coordinate32Value value)
    {
      return (UniversalMeasureValue)value.value;
    }

  }
}
