using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Element reprezentujący separator poziomy
  /// </summary>
  public partial class SeparatorMark: TextItem
  {
    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "SeParAtorMaRk".GetHashCode();
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
    /// Zwraca ciąg kresek poziomych. Długość zależna od typu
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
      switch (Type)
      {
        case SeparatorType.Begin:
          return new string('\u2015', 7);
        case SeparatorType.Separate:
          return new string('\u2015', 5);
        case SeparatorType.End:
          return new string('\u2015', 3);
      }
      return null;
    }

    /// <summary>
    /// Element nie jest pusty
    /// </summary>
    /// <returns></returns>
    public override bool IsEmpty ()
    {
      return false;
    }
  }
}
