using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa tabulatora
  /// </summary>
  public partial class TabStop : Item
  {

    /// <summary>typ tabulatora</summary>
    [DefaultValue(null)]
    public TabStopKind? Kind { get; set; }

    /// <summary>pozycja tabulatora</summary>
    [DefaultValue(null)]
    public PointValue Pos { get; set; }

    /// <summary>sekwencja znaków wiodących</summary>
    [DefaultValue(null)]
    public string Lead { get; set; }

    /// <summary>konstruktor domyślny</summary>
    public TabStop () { }

    /// <summary>konstruktor kopiujący</summary>
    public TabStop (TabStop obj)
    {
      this.Kind = obj.Kind;
      this.Pos = obj.Pos;
    }

    /// <summary>
    /// Stały skrót
    /// </summary>
    /// <returns></returns>
    public override int GetHash ()
    {
      if (Pos!=null)
        return Pos.GetHashCode();
      return "Pos".GetHashCode();
    }
  }

}
