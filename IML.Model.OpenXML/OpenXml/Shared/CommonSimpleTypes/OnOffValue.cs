using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Union]
  [Alias("OnOff")]
  public struct OnOffValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private OnOffValue (Boolean value)
    {
      this.value = value;
    }

    public Boolean AsBoolean
    {
      get
      {
        return (Boolean)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator OnOffValue (Boolean value)
    {
      return new OnOffValue(value);
    }

    public static implicit operator Boolean (OnOffValue value)
    {
      return (Boolean)value.value;
    }

  }
}
