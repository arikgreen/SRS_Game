using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ShadeTransformation
  {
    /// <summary>
    /// Przyciemnienie składowej luminancji
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override ARGBColor Transform (ARGBColor value)
    {
      HlsColor temp;
      temp = RealColor2HlsColor(value);
      temp.Luminance = Fix(temp.Luminance*Value);
      return HlsColor2RealColor(temp);
    }
  
  }
}
