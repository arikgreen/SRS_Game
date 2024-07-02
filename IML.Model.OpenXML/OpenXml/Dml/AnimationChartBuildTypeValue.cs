using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Union]
  [Alias("AnimationChartBuildType")]
  public struct AnimationChartBuildTypeValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private AnimationChartBuildTypeValue (AnimationBuildValues value)
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

    public static implicit operator AnimationChartBuildTypeValue (AnimationBuildValues value)
    {
      return new AnimationChartBuildTypeValue(value);
    }

    public static implicit operator AnimationBuildValues (AnimationChartBuildTypeValue value)
    {
      return (AnimationBuildValues)value.value;
    }

    private AnimationChartBuildTypeValue (AnimationChartOnlyBuildValues value)
    {
      this.value = value;
    }

    public AnimationChartOnlyBuildValues AsAnimationChartOnlyBuildValues
    {
      get
      {
        return (AnimationChartOnlyBuildValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator AnimationChartBuildTypeValue (AnimationChartOnlyBuildValues value)
    {
      return new AnimationChartBuildTypeValue(value);
    }

    public static implicit operator AnimationChartOnlyBuildValues (AnimationChartBuildTypeValue value)
    {
      return (AnimationChartOnlyBuildValues)value.value;
    }

  }
}
