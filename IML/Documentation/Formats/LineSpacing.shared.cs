using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class LineSpacing
  {
    /// <summary>
    /// Odstęp względem wysokości linii
    /// </summary>
    public static LineSpacing Relative (double value)
    {
      return new LineSpacing { Kind = LineSpacingKind.Relative, Value = value };
    }

    /// <summary>
    /// Odstęp minimalny liczony w punktach
    /// </summary>
    public static LineSpacing AtLeast (double value)
    {
      return new LineSpacing { Kind = LineSpacingKind.AtLeast, Value = value };
    }

    /// <summary>
    /// Odstęp dokładny liczony w punktach
    /// </summary>
    public static LineSpacing Exact (double value)
    {
      return new LineSpacing { Kind = LineSpacingKind.Exact, Value = value };
    }

    /// <summary>
    /// Odstęp automatyczny
    /// </summary>
    public static LineSpacing Auto
    {
      get { return auto; }
    }
    private static LineSpacing auto = new LineSpacing { Kind = LineSpacingKind.Auto };

  }
}
