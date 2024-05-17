using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa zastępująca string dla właściwości "Typeface". 
  /// Umożliwia zdefiniowanie różnych nazw czcionek dla różnych skryptów.
  /// </summary>
  public partial class Typeface
  {
    /// <summary>
    /// Podstawowa nazwa czcionki
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Czcionki zastępcze (dla różnych skryptów)
    /// </summary>
    public FontSubstitutes Substitutes
    {
      get
      {
        if (substitutes==null)
          substitutes =new FontSubstitutes(this);
        return substitutes;
      }
      set { substitutes=value; if (value!=null) value.SetOwner(this); }
    }
    private FontSubstitutes substitutes;

    /// <summary>
    /// Czy czcionki zastępcze są zdefiniowane?
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeFontSubstitutes()
    {
      return substitutes != null && !substitutes.IsEmpty();
    }
  }
}
