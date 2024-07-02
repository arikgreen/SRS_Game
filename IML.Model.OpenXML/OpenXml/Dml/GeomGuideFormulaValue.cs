using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("GeomGuideFormula")]
  public struct GeomGuideFormulaValue
  {
    private String value;

    private GeomGuideFormulaValue (String value)
    {
      this.value = value;
    }

    public String AsString
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator GeomGuideFormulaValue (String value)
    {
      return new GeomGuideFormulaValue(value);
    }

    public static implicit operator String (GeomGuideFormulaValue value)
    {
      return value.value;
    }

  }
}
