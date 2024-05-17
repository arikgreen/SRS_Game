using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("Index1")]
  public struct Index1Value
  {
    private UInt32 value;

    private Index1Value (UInt32 value)
    {
      this.value = value;
    }

    public UInt32 AsUInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator Index1Value (UInt32 value)
    {
      return new Index1Value(value);
    }

    public static implicit operator UInt32 (Index1Value value)
    {
      return value.value;
    }

  }
}
