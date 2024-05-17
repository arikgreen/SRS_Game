using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Format("X2")]
  [Alias("UcharHexNumber")]
  public struct UcharHexNumberValue
  {
    private Byte value;

    private UcharHexNumberValue (Byte value)
    {
      this.value = value;
    }

    public Byte AsByte
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator UcharHexNumberValue (Byte value)
    {
      return new UcharHexNumberValue(value);
    }

    public static implicit operator Byte (UcharHexNumberValue value)
    {
      return value.value;
    }

  }
}
