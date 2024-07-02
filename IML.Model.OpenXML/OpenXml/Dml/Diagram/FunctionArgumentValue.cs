using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Union]
  [Alias("FunctionArgument")]
  public struct FunctionArgumentValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private FunctionArgumentValue (VariableValues value)
    {
      this.value = value;
    }

    public VariableValues AsVariableValues
    {
      get
      {
        return (VariableValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator FunctionArgumentValue (VariableValues value)
    {
      return new FunctionArgumentValue(value);
    }

    public static implicit operator VariableValues (FunctionArgumentValue value)
    {
      return (VariableValues)value.value;
    }

  }
}
