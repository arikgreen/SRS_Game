using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.VML
{

  /// <summary>
  /// Abstrakcyjny obiekt języka VML
  /// </summary>
  public abstract partial class VmlItem: DocumentContent
  {
    /// <summary>
    /// Identyfikator VML elementu
    /// </summary>
    [DefaultValue(null)]
    public string VmlId { get; set; }

    /// <summary>
    /// Na razie nie jest pusty.
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }

    /// <summary>
    /// Obliczenie skrótu na podstawie numeru dodatkowego
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "VmlItEm".GetHashCode();
      if (VmlId != null)
        hash += VmlId.GetHashCode();
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }
  }
}
