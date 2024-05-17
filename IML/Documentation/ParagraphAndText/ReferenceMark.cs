using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Znacznik referencji do przypisu
  /// </summary>
  public partial class ReferenceMark: TextItem
  {

    /// <summary>
    /// Skrót obliczony na podstawie typu referencji
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      return (Type.ToString()+fId).GetHashCode();
    }

    /// <summary>
    /// Czy znacznik dotyczy tego przypisu
    /// </summary>
    [DefaultValue(false)]
    public bool This { get; set; }

    /// <summary>
    /// Typ przypisu
    /// </summary>
    public ReferenceMarkType Type { get; set; }

    /// <summary>
    /// Czy znak referencji jest ukryty
    /// </summary>
    [DefaultValue(null)]
    public bool? SuppressMark { get; set; }

    /// <summary>
    /// Zwraca łańcuch pusty
    /// </summary>
    /// <returns></returns>
    public override string GetString ()
    {
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
