using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("AdjCoordinate")]
  public struct AdjCoordinateValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private AdjCoordinateValue (CoordinateValue value)
    {
      this.value = value;
    }

    public CoordinateValue AsCoordinateValue
    {
      get
      {
        return (CoordinateValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator AdjCoordinateValue (CoordinateValue value)
    {
      return new AdjCoordinateValue(value);
    }

    public static implicit operator CoordinateValue (AdjCoordinateValue value)
    {
      return (CoordinateValue)value.value;
    }

    private AdjCoordinateValue (GeomGuideNameValue value)
    {
      this.value = value;
    }

    public GeomGuideNameValue AsGeomGuideNameValue
    {
      get
      {
        return (GeomGuideNameValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator AdjCoordinateValue (GeomGuideNameValue value)
    {
      return new AdjCoordinateValue(value);
    }

    public static implicit operator GeomGuideNameValue (AdjCoordinateValue value)
    {
      return (GeomGuideNameValue)value.value;
    }

  }
}
