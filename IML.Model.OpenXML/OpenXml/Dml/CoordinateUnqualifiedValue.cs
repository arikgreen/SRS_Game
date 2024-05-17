using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("CoordinateUnqualified")]
  public struct CoordinateUnqualifiedValue
  {
    private Int64 value;

    private CoordinateUnqualifiedValue (Int64 value)
    {
      this.value = value;
    }

    public Int64 AsInt64
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator CoordinateUnqualifiedValue (Int64 value)
    {
      return new CoordinateUnqualifiedValue(value);
    }

    public static implicit operator Int64 (CoordinateUnqualifiedValue value)
    {
      return value.value;
    }

  }
}
