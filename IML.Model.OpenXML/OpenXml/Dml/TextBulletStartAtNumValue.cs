using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextBulletStartAtNum")]
  public struct TextBulletStartAtNumValue
  {
    private Int32 value;

    private TextBulletStartAtNumValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextBulletStartAtNumValue (Int32 value)
    {
      return new TextBulletStartAtNumValue(value);
    }

    public static implicit operator Int32 (TextBulletStartAtNumValue value)
    {
      return value.value;
    }

  }
}
