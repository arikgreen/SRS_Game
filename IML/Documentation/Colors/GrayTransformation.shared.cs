using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class GrayTransformation
  {
    /// <summary>
    /// Przekształcenie składowych koloru na odcienie szarości
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override ARGBColor Transform (ARGBColor value)
    {
      double gray = Fix(0.21 * value.Red + 0.72 * value.Green + 0.07 * value.Blue);
      return new ARGBColor { Alpha = value.Alpha, Red = gray, Green = gray, Blue = gray };
    }

  }
}
