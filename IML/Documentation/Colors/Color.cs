using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Definicja koloru w dokumencie
  /// </summary>
  [Serializable]
  public partial class Color
  {


    /// <summary>
    /// Wartość do serializacji
    /// </summary>
    public virtual int Value
    {
      get;
      set;
    }

  }
}
