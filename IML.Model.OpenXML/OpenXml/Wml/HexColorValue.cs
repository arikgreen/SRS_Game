using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Union]
  [Alias("HexColor")]
  public struct HexColorValue
  {
    private object value;

    public Type Type
    {
      get
      {
        return value.GetType();
      }
    }

    private HexColorValue (AutomaticColorValues value)
    {
      this.value = value;
    }

    public AutomaticColorValues AsAutomaticColorValues
    {
      get
      {
        return (AutomaticColorValues)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator HexColorValue (AutomaticColorValues value)
    {
      return new HexColorValue(value);
    }

    public static implicit operator AutomaticColorValues (HexColorValue value)
    {
      return (AutomaticColorValues)value.value;
    }

    private HexColorValue (HexColorRGBValue value)
    {
      this.value = value;
    }

    public HexColorRGBValue AsHexColorRGBValue
    {
      get
      {
        return (HexColorRGBValue)value;
      }
      set
      {
        this.value = value;
      }
    }

    public static implicit operator HexColorValue (HexColorRGBValue value)
    {
      return new HexColorValue(value);
    }

    public static implicit operator HexColorRGBValue (HexColorValue value)
    {
      return (HexColorRGBValue)value.value;
    }

  }
}
