using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("TextPoint")]
  public struct TextPointValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private TextPointValue (TextPointUnqualifiedValue value)
    {
      this.value = value;
    }

    public TextPointUnqualifiedValue AsTextPointUnqualifiedValue
    {
      get
      {
        return (TextPointUnqualifiedValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator TextPointValue (TextPointUnqualifiedValue value)
    {
      return new TextPointValue(value);
    }

    public static implicit operator TextPointUnqualifiedValue (TextPointValue value)
    {
      return (TextPointUnqualifiedValue)value.value;
    }

    private TextPointValue (UniversalMeasureValue value)
    {
      this.value = value;
    }

    public UniversalMeasureValue AsUniversalMeasureValue
    {
      get
      {
        return (UniversalMeasureValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator TextPointValue (UniversalMeasureValue value)
    {
      return new TextPointValue(value);
    }

    public static implicit operator UniversalMeasureValue (TextPointValue value)
    {
      return (UniversalMeasureValue)value.value;
    }

  }
}
