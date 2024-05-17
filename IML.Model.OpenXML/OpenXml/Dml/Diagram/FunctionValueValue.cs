using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Union]
  [Alias("FunctionValue")]
  public struct FunctionValueValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private FunctionValueValue (Int32 value)
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

    public static implicit operator FunctionValueValue (Int32 value)
    {
      return new FunctionValueValue(value);
    }

    public static implicit operator Int32 (FunctionValueValue value)
    {
      return (Int32)value.value;
    }

    private FunctionValueValue (Boolean value)
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

    public static implicit operator FunctionValueValue (Boolean value)
    {
      return new FunctionValueValue(value);
    }

    public static implicit operator Boolean (FunctionValueValue value)
    {
      return (Boolean)value.value;
    }

    private FunctionValueValue (DirectionValues value)
    {
      this.value = value;
    }

    public DirectionValues AsDirectionValues
    {
      get
      {
        return (DirectionValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator FunctionValueValue (DirectionValues value)
    {
      return new FunctionValueValue(value);
    }

    public static implicit operator DirectionValues (FunctionValueValue value)
    {
      return (DirectionValues)value.value;
    }

    private FunctionValueValue (HierarchyBranchStyleValues value)
    {
      this.value = value;
    }

    public HierarchyBranchStyleValues AsHierarchyBranchStyleValues
    {
      get
      {
        return (HierarchyBranchStyleValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator FunctionValueValue (HierarchyBranchStyleValues value)
    {
      return new FunctionValueValue(value);
    }

    public static implicit operator HierarchyBranchStyleValues (FunctionValueValue value)
    {
      return (HierarchyBranchStyleValues)value.value;
    }

    private FunctionValueValue (AnimateOneByOneValues value)
    {
      this.value = value;
    }

    public AnimateOneByOneValues AsAnimateOneByOneValues
    {
      get
      {
        return (AnimateOneByOneValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator FunctionValueValue (AnimateOneByOneValues value)
    {
      return new FunctionValueValue(value);
    }

    public static implicit operator AnimateOneByOneValues (FunctionValueValue value)
    {
      return (AnimateOneByOneValues)value.value;
    }

    private FunctionValueValue (AnimationLevelStringValues value)
    {
      this.value = value;
    }

    public AnimationLevelStringValues AsAnimationLevelStringValues
    {
      get
      {
        return (AnimationLevelStringValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator FunctionValueValue (AnimationLevelStringValues value)
    {
      return new FunctionValueValue(value);
    }

    public static implicit operator AnimationLevelStringValues (FunctionValueValue value)
    {
      return (AnimationLevelStringValues)value.value;
    }

    private FunctionValueValue (ResizeHandlesStringValues value)
    {
      this.value = value;
    }

    public ResizeHandlesStringValues AsResizeHandlesStringValues
    {
      get
      {
        return (ResizeHandlesStringValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator FunctionValueValue (ResizeHandlesStringValues value)
    {
      return new FunctionValueValue(value);
    }

    public static implicit operator ResizeHandlesStringValues (FunctionValueValue value)
    {
      return (ResizeHandlesStringValues)value.value;
    }

  }
}
