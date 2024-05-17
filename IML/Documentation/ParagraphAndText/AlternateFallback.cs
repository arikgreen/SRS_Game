using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Element wyboru zawartości
  /// </summary>
  public partial class AlternateFallback : AlternateChoice
  {
    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "AltErnatEFalLback".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }

  }
}

