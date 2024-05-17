using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [MaxLength(65)]
  [Alias("FFName")]
  public struct FFNameValue
  {
    private String value;

    private FFNameValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator FFNameValue (String value)
    {
      return new FFNameValue(value);
    }

    public static implicit operator String (FFNameValue value)
    {
      return value.value;
    }

  }
}
