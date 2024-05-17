using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Wartość wariantowa
  /// </summary>
  [ContentProperty("Content")]
  public partial class VariantValue: Value
  {
    /// <summary>
    /// Zawartość - wartość konkretna
    /// </summary>
    public Value Content { get; set; }
  }
}
