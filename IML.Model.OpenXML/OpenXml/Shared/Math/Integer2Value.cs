using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [MinValue(-2)]
  [MaxValue(2)]
  [Alias("Integer2")]
  public struct Integer2Value
  {
    private Int32 value;

    private Integer2Value (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator Integer2Value (Int32 value)
    {
      return new Integer2Value(value);
    }

    public static implicit operator Int32 (Integer2Value value)
    {
      return value.value;
    }

  }
}
