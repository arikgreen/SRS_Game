using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  /// <summary>
  /// Lista transformacji koloru
  /// </summary>
  public partial class ColorTransformations: ObjectList<ColorTransformation>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ColorTransformations() {}

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ColorTransformations (object owner) : base(owner) { }
  }
}
