using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Union]
  [Alias("ModelId")]
  public struct ModelIdValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private ModelIdValue (Int32 value)
    {
      this.value = value;
    }

    public Int32 AsInt32
    {
      get
      {
        return (Int32)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ModelIdValue (Int32 value)
    {
      return new ModelIdValue(value);
    }

    public static implicit operator Int32 (ModelIdValue value)
    {
      return (Int32)value.value;
    }

    private ModelIdValue (Guid value)
    {
      this.value = value;
    }

    public Guid AsGuid
    {
      get
      {
        return (Guid)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator ModelIdValue (Guid value)
    {
      return new ModelIdValue(value);
    }

    public static implicit operator Guid (ModelIdValue value)
    {
      return (Guid)value.value;
    }

  }
}
