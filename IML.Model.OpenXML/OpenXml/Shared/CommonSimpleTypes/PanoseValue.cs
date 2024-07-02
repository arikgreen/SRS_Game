using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Length(10)]
  [Format("X20")]
  [Alias("Panose")]
  public struct PanoseValue
  {
    private Byte[] value;

    private PanoseValue (Byte[] value)
    {
      this.value = value;
    }

    public Byte[] AsByteArray
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PanoseValue (Byte[] value)
    {
      return new PanoseValue(value);
    }

    public static implicit operator Byte[] (PanoseValue value)
    {
      return value.value;
    }

  }
}
