using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("Coordinate32Unqualified")]
  public struct Coordinate32UnqualifiedValue
  {
    private Int32 value;

    private Coordinate32UnqualifiedValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator Coordinate32UnqualifiedValue (Int32 value)
    {
      return new Coordinate32UnqualifiedValue(value);
    }

    public static implicit operator Int32 (Coordinate32UnqualifiedValue value)
    {
      return value.value;
    }

  }
}
