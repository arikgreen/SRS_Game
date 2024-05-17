using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Styl listy
  /// </summary>
  public partial class ListStyle: Style
  {
    /// <summary>
    /// Typ stylu - czego dotyczy styl
    /// </summary>
    public override StyleType Type
    {
      get { return StyleType.List; }
    }
  }
}
