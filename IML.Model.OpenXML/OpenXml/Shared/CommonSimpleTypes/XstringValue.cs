using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Alias("Xstring")]
  public struct XstringValue
  {
    private String value;

    private XstringValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator XstringValue (String value)
    {
      return new XstringValue(value);
    }

    public static implicit operator String (XstringValue value)
    {
      return value.value;
    }

  }
}
