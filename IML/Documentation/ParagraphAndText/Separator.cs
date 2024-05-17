using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Element kończący deklarację pola w tekście.
  /// </summary>
  public partial class Separator: TextItem
  {
    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "SepAratOr".GetHashCode();
      if (Type != 0)
        hash += (int)Type;
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash; 
    }

    /// <summary>
    /// Typ separatora
    /// </summary>
    [DefaultValue(0)]
    public SeparatorType Type { get; set; }

    /// <summary>
    /// Ten znak nie jest widoczny
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
      return null;
    }

    /// <summary>
    /// Separator nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
