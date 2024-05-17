using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class InverseTransformation
  {
    /// <summary>
    /// Przekształcenie składowych koloru na uzupełniające
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override ARGBColor Transform (ARGBColor value)
    {
      return new ARGBColor { Alpha = value.Alpha, Red = Fix(1 - value.Red), 
        Green = Fix(1 - value.Green), Blue = Fix(1-value.Blue) };
    }

  }
}
