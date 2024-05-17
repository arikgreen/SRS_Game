using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista czcionek zastępczych
  /// </summary>
  public partial class FontSubstitutes: ObjectList<FontUsage>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public FontSubstitutes() {}

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public FontSubstitutes(object owner): base(owner) {}
  }
}
