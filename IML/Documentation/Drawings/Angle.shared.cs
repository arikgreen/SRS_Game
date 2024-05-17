using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  public partial class Angle
  {
    /// <summary>
    /// Niejawna transformacja na double
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator double (Angle val)
    {
      return val.Value;
    }

    /// <summary>
    /// Niejawna transformacja z double
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator Angle (double val)
    {
      return new Angle { Value = val };
    }

  }

}
