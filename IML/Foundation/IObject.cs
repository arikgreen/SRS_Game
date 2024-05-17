using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  /// <summary>
  /// Interfejs podstawowy
  /// </summary>
  public interface IObject
  {
    /// <summary>
    /// Umożliwia odwołanie się do obiektu, który implementuje interfejs
    /// </summary>
    Object Instance { get; }
  }
}
