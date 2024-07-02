using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Znak opcjonalnego podziału wyrazu
  /// </summary>
  public class SoftHyphen: TextItem
  {

    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "SoFtHyPhen".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }

    /// <summary>
    /// Tekstem zastępczym jest znak Unicode 00AD
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
      return "\u00AD";
    }

    /// <summary>
    /// Znak nie jest pusty
    /// </summary>
    public override bool IsEmpty ()
    {
      return false;
    }

  }
}
