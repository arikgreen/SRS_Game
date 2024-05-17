using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [MinValue(1)]
  [MaxValue(255)]
  [Alias("Integer255")]
  public struct Integer255Value
  {
    private Int32 value;

    private Integer255Value (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator Integer255Value (Int32 value)
    {
      return new Integer255Value(value);
    }

    public static implicit operator Int32 (Integer255Value value)
    {
      return value.value;
    }

  }
}
