using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextTypeface")]
  public struct TextTypefaceValue
  {
    private String value;

    private TextTypefaceValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextTypefaceValue (String value)
    {
      return new TextTypefaceValue(value);
    }

    public static implicit operator String (TextTypefaceValue value)
    {
      return value.value;
    }

  }
}
