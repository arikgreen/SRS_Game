using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [MaxLength(1)]
  [Alias("Char")]
  public struct CharValue
  {
    private String value;

    private CharValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator CharValue (String value)
    {
      return new CharValue(value);
    }

    public static implicit operator String (CharValue value)
    {
      return value.value;
    }

  }
}
