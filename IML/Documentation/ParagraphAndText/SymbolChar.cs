using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Znak reprezentujący symbol (niewidoczny)
  /// </summary>
  public partial class SymbolChar: TextItem
  {
    /// <summary>
    /// Ustalony kod skrótu 
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      int hash = "SymBolChar".GetHashCode();
      if (Code != null)
        hash += (int)Code;
      if (Collection != null)
        hash = Collection.MakeHashUnique(hash);
      return hash;
    }

    /// <summary>
    /// Kod znaku
    /// </summary>
    [DefaultValue(null)]
    public int? Code { get; set; }

    /// <summary>
    /// Czcionka znaku
    /// </summary>
    [DefaultValue(null)]
    public string Typeface { get; set; }

    /// <summary>
    /// Tekstem zastępczym jest odpowiedni znak Unicode
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
      return new String((char)Code, 1);
    }

    /// <summary>
    /// Czy symbol jest pusty?
    /// </summary>
    public override bool IsEmpty ()
    {
      return Code==null;
    }
  }
}
