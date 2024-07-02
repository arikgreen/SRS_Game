using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Znacznik końca błędu ortograficznego
  /// </summary>
  public partial class SpellErrorEnd: SpellError
  {
    /// <summary>
    /// Stały skrót
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "SpeLlErRorEnD".GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }
  }
}
