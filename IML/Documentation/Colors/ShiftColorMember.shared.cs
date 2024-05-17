using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ShiftColorMember
  {
    /// <summary>
    /// Przesunięcie składowej koloru
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override ARGBColor Transform (ARGBColor value)
    {
      HlsColor temp;
      switch (Member)
      {
        case ColorMembers.Alpha:
          return new ARGBColor { Alpha = Fix(value.Alpha+Value), Red = value.Red, Green = value.Green, Blue = value.Blue };
        case ColorMembers.Red:
          return new ARGBColor { Alpha = value.Alpha, Red = Fix(value.Red+Value), Green = value.Green, Blue = value.Blue };
        case ColorMembers.Green:
          return new ARGBColor { Alpha = value.Alpha, Red = value.Red, Green = Fix(value.Green+Value), Blue = value.Blue };
        case ColorMembers.Blue:
          return new ARGBColor { Alpha = value.Alpha, Red = value.Red, Green = value.Green, Blue = Fix(value.Blue+Value) };
        case ColorMembers.Hue:
          temp = RealColor2HlsColor(value);
          temp.Hue = Fix(temp.Hue+Value);
          return HlsColor2RealColor(temp);
        case ColorMembers.Luminance:
          temp = RealColor2HlsColor(value);
          temp.Luminance = (temp.Luminance+Value);
          return HlsColor2RealColor(temp);
        case ColorMembers.Saturation:
          temp = RealColor2HlsColor(value);
          temp.Saturation = Fix(temp.Saturation+Value);
          return HlsColor2RealColor(temp);
      }
      return value;
    }

  }
}
