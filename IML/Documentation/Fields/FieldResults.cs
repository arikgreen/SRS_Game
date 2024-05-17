using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista wyników pola. Mogą to być elementy typu <see cref="Run"/> albo <see cref="Block"/>
  /// </summary>
  public partial class FieldResults: ContentList
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public FieldResults () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public FieldResults (Item owner) : base(owner) { }
  }
}
