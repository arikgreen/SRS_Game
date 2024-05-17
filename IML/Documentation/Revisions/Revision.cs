using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Rewizja dokumentu
  /// </summary>
  public partial class Revision: Item
  {
    /// <summary>
    /// Identyfikator rewizji
    /// </summary>
    public override string Id { get; set; }
  }
}
