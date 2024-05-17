using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Pattern(@"0*((2[5-9])|([3-9][0-9])|([1-3][0-9][0-9])|400)%")]
  [Units(new string[]{"%"})]
  [Alias("TextBulletSizePercent")]
  public struct TextBulletSizePercentValue
  {
    private Int32 value;

    private TextBulletSizePercentValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get { return value; }
      set { this.value = value; }
    }

    public static implicit operator TextBulletSizePercentValue (Int32 value)
    {
      return new TextBulletSizePercentValue(value);
    }

    public static implicit operator Int32 (TextBulletSizePercentValue value)
    {
      return value.value;
    }

  }
}
