using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IML = Iml.Documentation;

namespace Iml.Documentation
{
  public partial class Color
  {
    /// <summary>
    /// Niejawny operator konwersji na kolor z <c>System.Drawing</c>
    /// </summary>
    /// <param name="aColor"></param>
    /// <returns></returns>
    public static implicit operator System.Drawing.Color(IML.Color aColor)
    {
      return System.Drawing.Color.FromArgb(aColor.A, aColor.R, aColor.G, aColor.B);
    }

    /// <summary>
    /// Niejawny operator konwersji z koloru <c>System.Drawing</c>
    /// </summary>
    /// <param name="aColor"></param>
    /// <returns></returns>
    public static implicit operator IML.Color (System.Drawing.Color aColor)
    {
      return IML.Color.FromArgb(aColor.A, aColor.R, aColor.G, aColor.B);
    }
  }
}
