using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DecimalNumber")]
  public struct DecimalNumberValue
  {
    private Int32 value;

    private DecimalNumberValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator DecimalNumberValue (Int32 value)
    {
      return new DecimalNumberValue(value);
    }

    public static implicit operator Int32 (DecimalNumberValue value)
    {
      return value.value;
    }

  }
}
