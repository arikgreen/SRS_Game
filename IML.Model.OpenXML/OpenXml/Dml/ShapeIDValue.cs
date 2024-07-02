using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Token]
  [Alias("ShapeID")]
  public struct ShapeIDValue
  {
    private String value;

    private ShapeIDValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator ShapeIDValue (String value)
    {
      return new ShapeIDValue(value);
    }

    public static implicit operator String (ShapeIDValue value)
    {
      return value.value;
    }

  }
}
