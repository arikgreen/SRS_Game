using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Alias("Lang")]
  public struct LangValue
  {
    private String value;

    private LangValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator LangValue (String value)
    {
      return new LangValue(value);
    }

    public static implicit operator String (LangValue value)
    {
      return value.value;
    }

  }
}
