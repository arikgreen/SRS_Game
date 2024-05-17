using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class GammaTransformation
  {
    /// <summary>
    /// Transformacja składowej luminancji wg funkcji gamma
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override ARGBColor Transform (ARGBColor value)
    {
      HlsColor temp;
      temp = RealColor2HlsColor(value);
      temp.Luminance = Fix(Math.Pow(temp.Luminance, Value));
      return HlsColor2RealColor(temp);
    }

  }
}
