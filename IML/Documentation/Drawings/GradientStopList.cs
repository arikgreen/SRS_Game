using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Lista punktów kontrolnych wypełnienia gradientowego
  /// </summary>
  public partial class GradientStopList: Iml.Foundation.ObjectList<GradientStop>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public GradientStopList(): base() {}

    /// <summary>
    /// Konstruktor z obiektem właścicielskim
    /// </summary>
    /// <param name="owner"></param>
    public GradientStopList(object owner): base(owner) {}
  }
}
