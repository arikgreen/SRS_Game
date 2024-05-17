using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Element oznaczający błąd w tekście
  /// </summary>
  public abstract partial class ProofError : TextItem
  {

    /// <summary>
    /// Ten element jest niewidoczny
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
      return null;
    }

    /// <summary>
    /// Ten element nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
