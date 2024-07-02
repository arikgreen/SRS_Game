using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista języków zastępczych
  /// </summary>
  public partial class LanguageSubstitutes : ObjectList<LanguageUsage>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public LanguageSubstitutes () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public LanguageSubstitutes (object owner) : base(owner) { }
  }
}
