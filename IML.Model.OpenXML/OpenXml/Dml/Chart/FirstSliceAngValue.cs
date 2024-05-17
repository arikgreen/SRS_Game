using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("FirstSliceAng")]
  public struct FirstSliceAngValue
  {
    private UInt16 value;

    private FirstSliceAngValue (UInt16 value)
    {
      this.value = value;
    }

    public UInt16 AsUInt16
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator FirstSliceAngValue (UInt16 value)
    {
      return new FirstSliceAngValue(value);
    }

    public static implicit operator UInt16 (FirstSliceAngValue value)
    {
      return value.value;
    }

  }
}
