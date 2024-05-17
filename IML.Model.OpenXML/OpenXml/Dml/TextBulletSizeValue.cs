using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("TextBulletSize")]
  public struct TextBulletSizeValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private TextBulletSizeValue (TextBulletSizePercentValue value)
    {
      this.value = value;
    }

    public TextBulletSizePercentValue AsTextBulletSizePercentValue
    {
      get
      {
        return (TextBulletSizePercentValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator TextBulletSizeValue (TextBulletSizePercentValue value)
    {
      return new TextBulletSizeValue(value);
    }

    public static implicit operator TextBulletSizePercentValue (TextBulletSizeValue value)
    {
      return (TextBulletSizePercentValue)value.value;
    }

  }
}
