using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Nakładanie wypełnienia
  /// </summary>
  public partial class FillOverlayTransformation: ImageTransformation
  {
    /// <summary>
    /// Wypełnienie nakładane
    /// </summary>
    [DefaultValue(null)]
    public Fill Fill { get; set; }
  }
}
