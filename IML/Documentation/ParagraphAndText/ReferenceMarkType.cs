using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Rodzaj referencji do przypisu
  /// </summary>
  public enum ReferenceMarkType
  {
    /// <summary>
    /// Referencja do przypisu dolnego
    /// </summary>
    Footnote,
    /// <summary>
    /// Referencja do przypisu końcowego
    /// </summary>
    Endnote,
    /// <summary>
    /// Referencja do adnotacji
    /// </summary>
    Annotation,
  }
}
