using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("AdjAngle")]
  public struct AdjAngleValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private AdjAngleValue (AngleValue value)
    {
      this.value = value;
    }

    public AngleValue AsAngleValue
    {
      get
      {
        return (AngleValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator AdjAngleValue (AngleValue value)
    {
      return new AdjAngleValue(value);
    }

    public static implicit operator AngleValue (AdjAngleValue value)
    {
      return (AngleValue)value.value;
    }

    private AdjAngleValue (GeomGuideNameValue value)
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

    public static implicit operator AdjAngleValue (GeomGuideNameValue value)
    {
      return new AdjAngleValue(value);
    }

    public static implicit operator GeomGuideNameValue (AdjAngleValue value)
    {
      return (GeomGuideNameValue)value.value;
    }

  }
}
