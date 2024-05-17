using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("StyleMatrixColumnIndex")]
  public struct StyleMatrixColumnIndexValue
  {
    private UInt32 value;

    private StyleMatrixColumnIndexValue (UInt32 value)
    {
      this.value = value;
    }

    public UInt32 AsUInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator StyleMatrixColumnIndexValue (UInt32 value)
    {
      return new StyleMatrixColumnIndexValue(value);
    }

    public static implicit operator UInt32 (StyleMatrixColumnIndexValue value)
    {
      return value.value;
    }

  }
}
