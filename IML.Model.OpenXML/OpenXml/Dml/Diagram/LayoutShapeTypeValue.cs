using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Union]
  [Alias("LayoutShapeType")]
  public struct LayoutShapeTypeValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private LayoutShapeTypeValue (ShapeTypeValues value)
    {
      this.value = value;
    }

    public ShapeTypeValues AsShapeTypeValues
    {
      get
      {
        return (ShapeTypeValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator LayoutShapeTypeValue (ShapeTypeValues value)
    {
      return new LayoutShapeTypeValue(value);
    }

    public static implicit operator ShapeTypeValues (LayoutShapeTypeValue value)
    {
      return (ShapeTypeValues)value.value;
    }

    private LayoutShapeTypeValue (OutputShapeValues value)
    {
      this.value = value;
    }

    public OutputShapeValues AsOutputShapeValues
    {
      get
      {
        return (OutputShapeValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator LayoutShapeTypeValue (OutputShapeValues value)
    {
      return new LayoutShapeTypeValue(value);
    }

    public static implicit operator OutputShapeValues (LayoutShapeTypeValue value)
    {
      return (OutputShapeValues)value.value;
    }

  }
}
