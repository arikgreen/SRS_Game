using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextPointUnqualified")]
  public struct TextPointUnqualifiedValue
  {
    private Int32 value;

    private TextPointUnqualifiedValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextPointUnqualifiedValue (Int32 value)
    {
      return new TextPointUnqualifiedValue(value);
    }

    public static implicit operator Int32 (TextPointUnqualifiedValue value)
    {
      return value.value;
    }

  }
}
