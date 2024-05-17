using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("PositionOffset")]
  public struct PositionOffset
  {
    private Int32 value;

    private PositionOffset (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PositionOffset (Int32 value)
    {
      return new PositionOffset(value);
    }

    public static implicit operator Int32 (PositionOffset value)
    {
      return value.value;
    }

  }
}
