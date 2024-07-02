using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Token]
  [Alias("GeomGuideName")]
  public struct GeomGuideNameValue
  {
    private String value;

    private GeomGuideNameValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator GeomGuideNameValue (String value)
    {
      return new GeomGuideNameValue(value);
    }

    public static implicit operator String (GeomGuideNameValue value)
    {
      return value.value;
    }

  }
}
