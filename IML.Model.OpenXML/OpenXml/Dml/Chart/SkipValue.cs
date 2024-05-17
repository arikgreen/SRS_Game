using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("Skip")]
  public struct SkipValue
  {
    private UInt32 value;

    private SkipValue (UInt32 value)
    {
      this.value = value;
    }

    public UInt32 AsUInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator SkipValue (UInt32 value)
    {
      return new SkipValue(value);
    }

    public static implicit operator UInt32 (SkipValue value)
    {
      return value.value;
    }

  }
}
