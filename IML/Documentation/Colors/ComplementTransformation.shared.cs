using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ComplementTransformation
  {
    /// <summary>
    /// Zmiana składowej Hue
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override ARGBColor Transform (ARGBColor value)
    {
      HlsColor temp;
      temp = RealColor2HlsColor(value);
      temp.Hue = Fix(temp.Hue + 180.0);
      return HlsColor2RealColor(temp);
    }

  }
}
