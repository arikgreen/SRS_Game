using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("AnimationDgmBuildType")]
  public struct AnimationDgmBuildTypeValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private AnimationDgmBuildTypeValue (AnimationBuildValues value)
    {
      this.value = value;
    }

    public AnimationBuildValues AsAnimationBuildValues
    {
      get
      {
        return (AnimationBuildValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator AnimationDgmBuildTypeValue (AnimationBuildValues value)
    {
      return new AnimationDgmBuildTypeValue(value);
    }

    public static implicit operator AnimationBuildValues (AnimationDgmBuildTypeValue value)
    {
      return (AnimationBuildValues)value.value;
    }

    private AnimationDgmBuildTypeValue (AnimationDiagramOnlyBuildValues value)
    {
      this.value = value;
    }

    public AnimationDiagramOnlyBuildValues AsAnimationDiagramOnlyBuildValues
    {
      get
      {
        return (AnimationDiagramOnlyBuildValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator AnimationDgmBuildTypeValue (AnimationDiagramOnlyBuildValues value)
    {
      return new AnimationDgmBuildTypeValue(value);
    }

    public static implicit operator AnimationDiagramOnlyBuildValues (AnimationDgmBuildTypeValue value)
    {
      return (AnimationDiagramOnlyBuildValues)value.value;
    }

  }
}
