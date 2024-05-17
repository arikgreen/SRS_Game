using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(-51206400)]
  [MaxValue(51206400)]
  [Alias("TextIndent")]
  public struct TextIndentValue
  {
    private Int32 value;

    private TextIndentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextIndentValue (Int32 value)
    {
      return new TextIndentValue(value);
    }

    public static implicit operator Int32 (TextIndentValue value)
    {
      return value.value;
    }

  }
}
