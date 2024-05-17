using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Element oznaczający podział strony przy ostatniej repaginacji
  /// </summary>
  public partial class LastRenderedPageBreak: TextItem
  {
    /// <summary>
    /// Stały skrót
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "LastReNderedPaGeBreak".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }

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
