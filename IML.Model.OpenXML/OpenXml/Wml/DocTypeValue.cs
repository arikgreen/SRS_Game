using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DocType")]
  public struct DocTypeValue
  {
    private String value;

    private DocTypeValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator DocTypeValue (String value)
    {
      return new DocTypeValue(value);
    }

    public static implicit operator String (DocTypeValue value)
    {
      return value.value;
    }

  }
}
