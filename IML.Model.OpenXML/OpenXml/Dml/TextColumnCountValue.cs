using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextColumnCount")]
  public struct TextColumnCountValue
  {
    private Int32 value;

    private TextColumnCountValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextColumnCountValue (Int32 value)
    {
      return new TextColumnCountValue(value);
    }

    public static implicit operator Int32 (TextColumnCountValue value)
    {
      return value.value;
    }

  }
}
