using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca styl "uśpiony", czyli taki, którego definicja nie jest znana dla dokumentu
  /// </summary>
  public partial class LatentStyle: Style
  {
    /// <summary>
    /// Styl uśpiony nie zna swojego typu
    /// </summary>
    public override StyleType Type
    {
      get { throw new NotImplementedException(); }
    }
  }
}
