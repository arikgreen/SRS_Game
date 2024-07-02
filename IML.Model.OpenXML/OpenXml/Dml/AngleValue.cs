using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("Angle")]
  public struct AngleValue
  {
    private Int32 value;

    private AngleValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator AngleValue (Int32 value)
    {
      return new AngleValue(value);
    }

    public static implicit operator Int32 (AngleValue value)
    {
      return value.value;
    }

  }
}
