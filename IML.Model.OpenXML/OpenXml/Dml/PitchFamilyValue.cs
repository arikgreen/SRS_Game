using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PitchFamily")]
  public struct PitchFamilyValue
  {
    private SByte value;

    private PitchFamilyValue (SByte value)
    {
      this.value = value;
    }

    public SByte AsSByte
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator PitchFamilyValue (SByte value)
    {
      return new PitchFamilyValue(value);
    }

    public static implicit operator SByte (PitchFamilyValue value)
    {
      return value.value;
    }

  }
}
