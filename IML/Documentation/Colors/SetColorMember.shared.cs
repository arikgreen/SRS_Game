using Iml.Documentation.Drawings;
using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class SetColorMember
  {
    /// <summary>
    /// Ustawienie składowej koloru
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override ARGBColor Transform (ARGBColor value)
    {
      HlsColor temp;
      switch (Member)
      {
        case ColorMembers.Alpha:
          return new ARGBColor { Alpha = Fix(Value), Red = value.Red, Green = value.Green, Blue = value.Blue };
        case ColorMembers.Red:
          return new ARGBColor { Alpha = value.Alpha, Red = Fix(Value), Green = value.Green, Blue = value.Blue };
        case ColorMembers.Green:
          return new ARGBColor { Alpha = value.Alpha, Red = value.Red, Green = Fix(Value), Blue = value.Blue };
        case ColorMembers.Blue:
          return new ARGBColor { Alpha = value.Alpha, Red = value.Red, Green = value.Green, Blue = Fix(Value) };
        case ColorMembers.Hue:
          temp = RealColor2HlsColor(value);
          temp.Hue = Fix360(Value);
          return HlsColor2RealColor(temp);
        case ColorMembers.Luminance:
          temp = RealColor2HlsColor(value);
          temp.Luminance = Fix(Value);
          return HlsColor2RealColor(temp);
        case ColorMembers.Saturation:
          temp = RealColor2HlsColor(value);
          temp.Saturation = Fix(Value);
          return HlsColor2RealColor(temp);
      }
      return value;
    }


  }
}
