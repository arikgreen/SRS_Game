using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Abstrakcyjny efekt graficzny
  /// </summary>
  public abstract class Effect: Item
  {
    /// <summary>
    ///  Identyfikator nie jest serializowany
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        return null;
      }
      set
      {
        base.Id = value;
      }
    }
  }
}
