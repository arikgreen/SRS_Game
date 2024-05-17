using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Znacznik początku błędu ortograficznego
  /// </summary>
  public partial class SpellErrorBegin: SpellError
  {
    /// <summary>
    /// Stały skrót
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "SpeLlErRorBeGin".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }
  }
}
