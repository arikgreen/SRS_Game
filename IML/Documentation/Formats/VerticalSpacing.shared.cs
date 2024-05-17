using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class VerticalSpacing
  {

    /// <summary>
    /// Odstęp liczony w punktach
    /// </summary>
    public static VerticalSpacing Exact (double value)
    {
      return new VerticalSpacing { Kind = VerticalSpacingKind.Exact, Value = value };
    }

    /// <summary>
    /// Odstęp liczony w liniach
    /// </summary>
    public static VerticalSpacing Relative (double value)
    {
      return new VerticalSpacing { Kind = VerticalSpacingKind.Relative, Value = value };
    }

    /// <summary>
    /// Odstęp automatyczny
    /// </summary>
    public static VerticalSpacing Auto
    {
      get { return auto; }
    }
    private static VerticalSpacing auto = new VerticalSpacing { Kind = VerticalSpacingKind.Auto };
  }
}
