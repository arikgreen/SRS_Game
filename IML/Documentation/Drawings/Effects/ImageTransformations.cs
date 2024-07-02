using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Lista transformacji obrazu
  /// </summary>
  public partial class ImageTransformations : ObjectList<ImageTransformation>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ImageTransformations () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ImageTransformations (object owner) : base(owner) { }
  }
}

