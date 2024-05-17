using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextIndentLevelType")]
  public struct TextIndentLevelTypeValue
  {
    private Int32 value;

    private TextIndentLevelTypeValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextIndentLevelTypeValue (Int32 value)
    {
      return new TextIndentLevelTypeValue(value);
    }

    public static implicit operator Int32 (TextIndentLevelTypeValue value)
    {
      return value.value;
    }

  }
}
