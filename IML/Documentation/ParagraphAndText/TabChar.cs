using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Iml.Foundation;

namespace Iml.Documentation
{

  /// <summary>
  /// Znak tabulacji w tekście
  /// </summary>
  public partial class TabChar: TextItem
  {
    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "TaBchAr".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }

    /// <summary>
    /// Tekstem zastępczym jest znak tabulacji
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
      return "\t";
    }

    /// <summary>
    /// Znak tabulacji nie jest pusty
    /// </summary>
    public override bool IsEmpty()
    {
      return false;
    }

  }
}
