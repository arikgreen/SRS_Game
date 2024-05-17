using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [NCName]
  [MaxLength(255)]
  [Alias("XmlName")]
  public struct XmlNameValue
  {
    private String value;

    private XmlNameValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator XmlNameValue (String value)
    {
      return new XmlNameValue(value);
    }

    public static implicit operator String (XmlNameValue value)
    {
      return value.value;
    }

  }
}
