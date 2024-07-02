using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista rozszerzeń
  /// </summary>
  public partial class ExtensionList: ObjectList<Extension>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ExtensionList () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ExtensionList (object owner) : base(owner) { }
  }
}
