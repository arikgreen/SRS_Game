using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [MaxLength(33)]
  [Alias("MacroName")]
  public struct MacroNameValue
  {
    private String value;

    private MacroNameValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator MacroNameValue (String value)
    {
      return new MacroNameValue(value);
    }

    public static implicit operator String (MacroNameValue value)
    {
      return value.value;
    }

  }
}
